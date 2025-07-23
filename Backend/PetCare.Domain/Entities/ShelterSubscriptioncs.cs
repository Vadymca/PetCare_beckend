using PetCare.Domain.Common;

namespace PetCare.Domain.Entities
{
    public sealed class ShelterSubscription : ValueObject
    {
        public Guid UserId { get; private set; }
        public Guid ShelterId { get; private set; }
        public DateTime SubscribedAt { get; private set; }

        private ShelterSubscription() { }

        private ShelterSubscription(Guid userId, Guid shelterId, DateTime subscribedAt)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));

            if (shelterId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор притулку не може бути порожнім.", nameof(shelterId));

            UserId = userId;
            ShelterId = shelterId;
            SubscribedAt = subscribedAt;
        }

        public static ShelterSubscription Create(Guid userId, Guid shelterId) =>
            new ShelterSubscription(userId, shelterId, DateTime.UtcNow);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return ShelterId;
        }
    }
}
