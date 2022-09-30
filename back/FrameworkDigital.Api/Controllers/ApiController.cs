using FrameworkDigital.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FrameworkDigital.Api.Controllers
{
    [Produces("application/json")]
    public abstract class ApiController : Controller
    {

        protected readonly DomainNotificationHandler _notifications;

        public ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected new IActionResult Response(object? result = null)
        {
            if (OperationIsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = GetNotifications()
            });
        }

        protected bool OperationIsValid() => (!_notifications.HasNotifications());

        protected List<string> GetNotifications()
        {
            var notifications = _notifications.GetNotifications();
            var errors = new List<string>(notifications.Count);

            foreach (var item in notifications)
            {
                if (!String.IsNullOrWhiteSpace(item.Message))
                    errors.Add(item.Message);
            }

            return errors;
        }

    }
}
