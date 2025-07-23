using PetCare.Domain.Common;

namespace PetCare.Domain.Entities
{
    public sealed class VolunteerTaskAssignment : ValueObject
    {
        public Guid VolunteerTaskId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime AssignedAt { get; private set; }

        private VolunteerTaskAssignment() { }

        private VolunteerTaskAssignment(
            Guid volunteerTaskId, 
            Guid userId, 
            DateTime assignedAt)
        {
            if (volunteerTaskId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор завдання волонтера не може бути порожнім.", nameof(volunteerTaskId));

            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));

            VolunteerTaskId = volunteerTaskId;
            UserId = userId;
            AssignedAt = assignedAt;
        }

        public static VolunteerTaskAssignment Create(Guid volunteerTaskId, Guid userId) =>
            new VolunteerTaskAssignment(volunteerTaskId, userId, DateTime.UtcNow);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return VolunteerTaskId;
            yield return UserId;
        }
    }
}
