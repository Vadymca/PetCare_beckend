using PetCare.Domain.Common;

namespace PetCare.Domain.Entities
{
    public sealed class NotificationType : BaseEntity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }

        private NotificationType() { }

        private NotificationType(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва типу сповіщення не може бути порожньою.", nameof(name));

            Name = name.Trim();
            Description = description?.Trim();
        }

        public static NotificationType Create(string name, string? description = null)
        {
            return new NotificationType(name, description);
        }

        public void Update(string? name = null, string? description = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name.Trim();

            if (description is not null)
                Description = description.Trim();
        }
    }
}
