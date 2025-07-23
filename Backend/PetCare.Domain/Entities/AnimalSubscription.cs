using PetCare.Domain.Common;

namespace PetCare.Domain.Entities
{
    public sealed class AnimalSubscription : ValueObject
    {
        public Guid UserId { get; private set; }
        public Guid AnimalId { get; private set; }
        public DateTime SubscribedAt { get; private set; }

        private AnimalSubscription() { }

        private AnimalSubscription(Guid userId, Guid animalId, DateTime subscribedAt)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));

            if (animalId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор тварини не може бути порожнім.", nameof(animalId));

            UserId = userId;
            AnimalId = animalId;
            SubscribedAt = subscribedAt;
        }

        public static AnimalSubscription Create(Guid userId, Guid animalId) =>
            new AnimalSubscription(userId, animalId, DateTime.UtcNow);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return AnimalId;
        }

    }
}
