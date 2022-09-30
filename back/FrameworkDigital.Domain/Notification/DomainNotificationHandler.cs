using MediatR;

namespace FrameworkDigital.Domain.Notification
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public virtual List<DomainNotification> GetNotifications() => _notifications;

        public virtual bool HasNotifications() => _notifications.Any();

        public void Dispose() => _notifications = new List<DomainNotification>();

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }
    }
}
