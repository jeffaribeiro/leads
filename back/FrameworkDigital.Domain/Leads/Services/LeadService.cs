using FrameworkDigital.Application.Leads.DTO;
using FrameworkDigital.Application.Leads.Service;
using FrameworkDigital.Domain.Leads.Mappings;
using FrameworkDigital.Domain.Leads.Repository;
using FrameworkDigital.Domain.Notification;
using FrameworkDigital.Domain.UoW;
using FrameworkDigital.Infra.SendEmail;
using MediatR;

namespace FrameworkDigital.Domain.Leads.Services
{
    public class LeadService : ILeadService
    {

        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHandler<DomainNotification> _notificationHandler;
        private readonly IEmailService _emailService;

        public LeadService(ILeadRepository leadRepository,
                           IUnitOfWork unitOfWork,
                           INotificationHandler<DomainNotification> notificationHandler,
                           IEmailService emailService)
        {
            _leadRepository = leadRepository;
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
            _emailService = emailService;
        }

        public async Task AcceptLead(long id)
        {
            var lead = _leadRepository.GetById(id);

            if (lead == null)
            {
                await _notificationHandler.Handle(new DomainNotification("Lead", "The ID doesn't exists"), CancellationToken.None);
                return;
            }

            lead.Accept();
            _leadRepository.Update(lead);
            _unitOfWork.Commit();
            _emailService.SendEmailToSalesDepartment();
        }

        public async Task DeclineLead(long id)
        {
            var lead = _leadRepository.GetById(id);

            if (lead == null)
            {
                await _notificationHandler.Handle(new DomainNotification("Lead", "The ID doesn't exists"), CancellationToken.None);
                return;
            }

            lead.Decline();
            _leadRepository.Update(lead);
            _unitOfWork.Commit();
        }

        public IList<LeadAcceptedDto> GetAllLeadsAccepted()
        {
            var leads = _leadRepository.GetAccepteds();
            var leadsAccepted = new List<LeadAcceptedDto>();

            if (leads != null && leads.Count > 0)
            {
                foreach (var item in leads)
                    leadsAccepted.Add(LeadAcceptedDtoMap.ToDto(item));
            }

            return leadsAccepted;
        }

        public IList<LeadInvitedDto> GetAllLeadsInvited()
        {
            var leads = _leadRepository.GetInviteds();
            var leadsInvited = new List<LeadInvitedDto>();

            if (leads != null && leads.Count > 0)
            {
                foreach (var item in leads)
                    leadsInvited.Add(LeadInvitedDtoMap.ToDto(item));
            }

            return leadsInvited;
        }
    }
}
