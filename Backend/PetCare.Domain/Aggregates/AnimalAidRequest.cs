using PetCare.Domain.Common;
using PetCare.Domain.Enums;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Aggregates
{
    public sealed class AnimalAidRequest : BaseEntity
    {
        public Guid? UserId { get; private set; }
        public Guid? ShelterId { get; private set; }
        public Title Title { get; private set; }
        public string? Description { get; private set; }
        public AidCategory Category { get; private set; }
        public AidStatus Status { get; private set; }
        public float? EstimatedCost { get; private set; }
        public List<string> Photos { get; private set; } = new();
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set;}

        private AnimalAidRequest() { }

        private AnimalAidRequest(
            Guid? userId,
            Guid? shelterId,
            Title title,
            string? description,
            AidCategory category,
            AidStatus status,
            float? estimatedCost,
            List<string>? photos)
        {
            if(estimatedCost is < 0)
                throw new ArgumentOutOfRangeException(nameof(estimatedCost), "Орієнтовна вартість має бути невід'ємною");
            UserId = userId;
            ShelterId = shelterId;
            Title = title;
            Description = description;
            Category = category;
            Status = status;
            EstimatedCost = estimatedCost;
            Photos = photos ?? new List<string>();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static AnimalAidRequest Create(
            Guid? userId,
            Guid? shelterId,
            string title,
            string? description,
            AidCategory category,
            AidStatus status,
            float? estimatedCost,
            List<string>? photos)
        {
            return new AnimalAidRequest(
                userId,
                shelterId,
                Title.Create(title),
                description,
                category,
                status,
                estimatedCost,
                photos
            );
        }

        public void UpdateStatus(AidStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateEstimatedCost(float? newCost)
        {
            if (newCost is < 0)
                throw new ArgumentOutOfRangeException(nameof(newCost), "Вартість повинна бути невід'ємною.");

            EstimatedCost = newCost;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
