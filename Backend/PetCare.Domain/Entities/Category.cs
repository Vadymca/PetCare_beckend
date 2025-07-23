using PetCare.Domain.Common;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public Name Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Category() { }

        private Category(Name name, string? description)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public static Category Create(string name, string? description = null)
        {
            return new Category(Name.Create(name), description);
        }

        public void Update(string? name = null, string? description = null)
        {
            if (name is not null)
                Name = Name.Create(name);

            if (description is not null)
                Description = description;
        }
    }
}
