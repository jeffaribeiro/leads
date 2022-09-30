using FrameworkDigital.Application.Leads.DTO;

namespace FrameworkDigital.Application.Leads.Service
{
    public interface ILeadService
    {
        Task AcceptLead(long id);
        Task DeclineLead(long id);
        IList<LeadInvitedDto> GetAllLeadsInvited();
        IList<LeadAcceptedDto> GetAllLeadsAccepted();
    }
}
