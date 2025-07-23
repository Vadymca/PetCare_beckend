using PetCare.Domain.Common;

namespace PetCare.Domain.Aggregates
{
    public sealed class GamificationReward : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid? TaskId { get; private set; }
        public int Points { get; private set; }
        public string? Description { get; private set; }
        public bool Used { get; private set; }
        public DateTime AwardedAt { get; private set; }

        private GamificationReward() { }

        private GamificationReward(
            Guid userId,
            Guid? taskId,
            int points,
            string? description,
            bool used,
            DateTime awardedAt)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));

            if (points < 0)
                throw new ArgumentOutOfRangeException(nameof(points), "Бали не можуть бути від'ємними.");

            UserId = userId;
            TaskId = taskId;
            Points = points;
            Description = description;
            Used = used;
            AwardedAt = awardedAt;
        }

        public static GamificationReward Create(
            Guid userId,
            Guid? taskId,
            int points,
            string? description = null,
            bool used = false)
        {
            return new GamificationReward(
                userId,
                taskId,
                points,
                description,
                used,
                DateTime.UtcNow
            );
        }

        public void MarkAsUsed()
        {
            Used = true;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
        }
    }
}
