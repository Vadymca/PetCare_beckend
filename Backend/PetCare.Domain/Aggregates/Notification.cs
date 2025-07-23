using PetCare.Domain.Common;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Aggregates
{
    public sealed class Notification : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid NotificationTypeId { get; private set; }
        public Title Title { get; private set; } = default!;
        public string Message { get; private set; } = default!;
        public bool IsRead { get; private set; }
        public string? NotifiableEntity { get; private set; }
        public Guid? NotifiableEntityId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Notification() { }

        private Notification(
           Guid userId,
           Guid notificationTypeId,
           Title title,
           string message,
           string? notifiableEntity,
           Guid? notifiableEntityId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));

            if (notificationTypeId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор типу сповіщення не може бути порожнім.", nameof(notificationTypeId));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Повідомлення не може бути порожнім.", nameof(message));

            UserId = userId;
            NotificationTypeId = notificationTypeId;
            Title = title;
            Message = message;
            NotifiableEntity = notifiableEntity;
            NotifiableEntityId = notifiableEntityId;
            IsRead = false;
            CreatedAt = DateTime.UtcNow;
        }

        public static Notification Create(
            Guid userId,
            Guid notificationTypeId,
            string title,
            string message,
            string? notifiableEntity = null,
            Guid? notifiableEntityId = null)
        {
            return new Notification(
                userId,
                notificationTypeId,
                Title.Create(title),
                message,
                notifiableEntity,
                notifiableEntityId);
        }
        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
