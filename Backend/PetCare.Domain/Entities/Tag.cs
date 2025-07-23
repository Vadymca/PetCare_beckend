using PetCare.Domain.Common;

namespace PetCare.Domain.Entities
{
    public sealed class Tag : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string? Icon { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Tag() { }

        private Tag(string name, string? icon)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ім'я не може бути порожнім.", nameof(name));

            Name = name.Trim();
            Icon = string.IsNullOrWhiteSpace(icon) ? null : icon.Trim();
            CreatedAt = DateTime.UtcNow;
        }

        public static Tag Create(string name, string? icon = null)
        {
            return new Tag(name, icon);
        }

        public void Update(string? name = null, string? icon = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name.Trim();

            Icon = icon?.Trim();
        }
    }
}
