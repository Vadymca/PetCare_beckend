using PetCare.Domain.Common;
namespace PetCare.Domain.Entities
{
    public sealed class EventParticipant : ValueObject
    {
        public Guid EventId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime RegisteredAt { get; private set; }

        private EventParticipant() { }

        private EventParticipant(Guid eventId, Guid userId, DateTime registeredAt)
        {
            if (eventId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор події не може бути порожнім.", nameof(eventId));

            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));

            EventId = eventId;
            UserId = userId;
            RegisteredAt = registeredAt;
        }

        public static EventParticipant Create(Guid eventId, Guid userId) =>
            new EventParticipant(eventId, userId, DateTime.UtcNow);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EventId;
            yield return UserId;
        }
    }
}
