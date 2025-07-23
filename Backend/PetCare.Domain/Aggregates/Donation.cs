using PetCare.Domain.Common;
using PetCare.Domain.Enums;

namespace PetCare.Domain.Aggregates
{
    public sealed class Donation : BaseEntity
    {
        public Guid? UserId { get; private set; }
        public float Amount { get; private set; }
        public Guid? ShelterId { get; private set; }
        public Guid PaymentMethodId { get; private set; }
        public DonationStatus Status { get; private set; }
        public string? TransactionId { get; private set; }
        public string? Purpose {  get; private set; }
        public bool Recurring { get; private set; }
        public bool Anonymous { get; private set; }
        public DateTime DonationDate { get; private set; }
        public string? Report {  get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Donation() { }

        private Donation(
            Guid? userId,
            float amount,
            Guid? shelterId,
            Guid paymentMethodId,
            DonationStatus status,
            string? transactionId,
            string? purpose,
            bool recurring,
            bool anonymous,
            DateTime? donationDate,
            string? report)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума повинна бути більшою за 0.", nameof(amount));

            UserId = userId;
            Amount = amount;
            ShelterId = shelterId;
            PaymentMethodId = paymentMethodId;
            Status = status;
            TransactionId = transactionId;
            Purpose = purpose;
            Recurring = recurring;
            Anonymous = anonymous;
            DonationDate = donationDate ?? DateTime.UtcNow;
            Report = report;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Donation Create(
            Guid? userId,
            float amount,
            Guid? shelterId,
            Guid paymentMethodId,
            DonationStatus status,
            string? transactionId = null,
            string? purpose = null,
            bool recurring = false,
            bool anonymous = false,
            DateTime? donationDate = null,
            string? report = null)
        {
            return new Donation(
               userId,
               amount,
               shelterId,
               paymentMethodId,
               status,
               transactionId,
               purpose,
               recurring,
               anonymous,
               donationDate,
               report
            );
        }

        public void UpdateReport(string report)
        {
            Report = report;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsCompleted(string? transactionId = null)
        {
            Status = DonationStatus.Completed;
            if (!string.IsNullOrWhiteSpace(transactionId)) 
                TransactionId = transactionId;

            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsFailed()
        {
            Status = DonationStatus.Failed;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetStatus(DonationStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
