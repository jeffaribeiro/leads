using FrameworkDigital.Application.Leads.Service;
using FrameworkDigital.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FrameworkDigital.Api.Controllers
{
    [Route("lead")]
    [ApiController]
    public class LeadController : ApiController
    {
        private readonly ILeadService _leadService;

        public LeadController(INotificationHandler<DomainNotification> notifications, ILeadService leadService) : base(notifications)
        {
            _leadService = leadService;
        }

        [HttpGet]
        [Route("accepted-leads")]
        public IActionResult GetAcceptedLeads()
        {
            var result = _leadService.GetAllLeadsAccepted();
            return Response(result);
        }

        [HttpGet]
        [Route("invited-leads")]
        public IActionResult GetInvitedLeads()
        {
            var result = _leadService.GetAllLeadsInvited();
            return Response(result);
        }

        [HttpPut]
        [Route("accept/{id}")]
        public IActionResult Accept(long id)
        {
            _leadService.AcceptLead(id);
            return Response();
        }

        [HttpPut]
        [Route("decline/{id}")]
        public IActionResult Decline(long id)
        {
            _leadService.DeclineLead(id);
            return Response();
        }
    }
}