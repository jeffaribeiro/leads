using MediatR;

namespace FrameworkDigital.Domain.Notification
{
    public class DomainNotification : INotification
    {
        public string Entity { get; private set; }
        public string Message { get; private set; }

        public DomainNotification(string entity, string message)
        {
            Entity = entity;
            Message = message;
        }
    }
}
