using PetCare.Domain.Common;
using PetCare.Domain.Enums;

namespace PetCare.Domain.Aggregates
{
    public sealed class AdoptionApplication : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid AnimalId { get; private set; }
        public AdoptionStatus Status { get; private set; }
        public DateTime ApplicationDate { get; private set; }
        public string? Comment { get; private set; }
        public string? AdminNotes { get; private set; }
        public Guid? ApprovedBy { get; private set; }
        public string? RejectionReason { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private AdoptionApplication() { }

        private AdoptionApplication(
            Guid userId,
            Guid animalId,
            string? comment)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));
            if (animalId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор тварини не може бути порожнім.", nameof(animalId));
            UserId = userId;
            AnimalId = animalId;
            Comment = comment;
            Status = AdoptionStatus.Pending;
            ApplicationDate = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static AdoptionApplication Create(Guid userId, Guid animalId, string? comment)
            => new(userId, animalId, comment);

        public void Approve(Guid adminId)
        {
            if (Status != AdoptionStatus.Pending)
                throw new InvalidOperationException("Затверджуються лише ті заявки, які знаходяться на розгляді.");

            Status = AdoptionStatus.Approved;
            ApprovedBy = adminId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Reject(string reason)
        {
            if (Status != AdoptionStatus.Pending)
                throw new InvalidOperationException("Відхилити можна лише ті заявки, що перебувають на розгляді.");

            Status = AdoptionStatus.Rejected;
            RejectionReason = reason;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddAdminNotes(string notes)
        {
            AdminNotes = notes;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
