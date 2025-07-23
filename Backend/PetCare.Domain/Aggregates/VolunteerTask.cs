using NetTopologySuite.Geometries;
using PetCare.Domain.Common;
using PetCare.Domain.Enums;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Aggregates
{
    public sealed class VolunteerTask : BaseEntity
    {
        public Guid ShelterId { get; private set; }
        public Title Title { get; private set; }
        public string? Description { get; private set; }
        public DateOnly Date {  get; private set; }
        public int? Duration { get; private set; }
        public int RequiredVolunteers { get; private set; }
        public VolunteerTaskStatus Status { get; private set; }
        public int PointsReward { get; private set; }
        public Point? Location { get; private set; }
        public Dictionary<string, string> SkillsRequired { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private VolunteerTask() { }
        private VolunteerTask(
            Guid shelterId,
            Title title, 
            string? description, 
            DateOnly date, 
            int? duration, 
            int requiredVolunteers, 
            VolunteerTaskStatus status, 
            int pointsReward, 
            Point? location, 
            Dictionary<string, string> skillsRequired)
        {
            if (requiredVolunteers <= 0)
                throw new ArgumentOutOfRangeException(nameof(requiredVolunteers), "Повинно бути більше нуля");

            if (duration.HasValue && duration <= 0)
                throw new ArgumentOutOfRangeException(nameof(duration), "Якщо вказано, має бути більше нуля.");

            if (pointsReward < 0)
                throw new ArgumentOutOfRangeException(nameof(pointsReward), "Не може бути негативним.");

            ShelterId = shelterId;
            Title = title;
            Description = description?.Trim();
            Date = date;
            Duration = duration;
            RequiredVolunteers = requiredVolunteers;
            Status = status;
            PointsReward = pointsReward;
            Location = location;
            SkillsRequired = skillsRequired;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static VolunteerTask Create(
            Guid shelterId,
            string title,
            string? description,
            DateOnly date,
            int? duration,
            int requiredVolunteers,
            VolunteerTaskStatus status,
            int pointsReward,
            Point? location,
            Dictionary<string, string>? skillsRequired)
        {
            return new VolunteerTask(
                shelterId,
                Title.Create(title),
                description,
                date,
                duration,
                requiredVolunteers,
                status,
                pointsReward,
                location,
                skillsRequired);
        }

        public void UpdateStatus(VolunteerTaskStatus newStatus)
        {
            Status = newStatus;
            UpdatedAt= DateTime.UtcNow;
        }

        public void UpdateInfo(
            string title,
            string? description,
            DateOnly date,
            int? duration,
            int requiredVolunteers,
            int pointsReward,
            Point? location,
            Dictionary<string, string>? skillsRequired)
        {
            if (requiredVolunteers <= 0)
                throw new ArgumentOutOfRangeException(nameof(requiredVolunteers));

            if (duration.HasValue && duration <= 0)
                throw new ArgumentOutOfRangeException(nameof(duration));

            if (pointsReward < 0)
                throw new ArgumentOutOfRangeException(nameof(pointsReward));

            Title = Title.Create(title);
            Description = description?.Trim();
            Date = date;
            Duration = duration;
            RequiredVolunteers = requiredVolunteers;
            PointsReward = pointsReward;
            Location = location;
            SkillsRequired = skillsRequired;
            UpdatedAt = DateTime.UtcNow;

        }
    }
}
