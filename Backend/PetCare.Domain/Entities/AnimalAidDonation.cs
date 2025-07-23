using PetCare.Domain.Common;

namespace PetCare.Domain.Entities
{
    public sealed class AnimalAidDonation : ValueObject
    {
        public Guid DonationId { get; private set; }
        public Guid AnimalAidRequestId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private AnimalAidDonation() { }

        private AnimalAidDonation(Guid donationId, Guid animalAidRequestId, DateTime createdAt)
        {
            if (donationId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор донації не може бути порожнім.", nameof(donationId));

            if (animalAidRequestId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор запиту на допомогу тварині не може бути порожнім.", nameof(animalAidRequestId));

            DonationId = donationId;
            AnimalAidRequestId = animalAidRequestId;
            CreatedAt = createdAt;
        }

        public static AnimalAidDonation Create(Guid donationId, Guid animalAidRequestId)
        {
            return new AnimalAidDonation(
                donationId,
                animalAidRequestId,
                DateTime.UtcNow
            );
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DonationId;
            yield return AnimalAidRequestId;
        }
    }
}
