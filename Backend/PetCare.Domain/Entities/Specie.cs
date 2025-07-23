using PetCare.Domain.Common;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Entities
{
    public sealed class Specie : BaseEntity
    {
        public Name Name { get; private set; }

        private Specie() { }
    
        private Specie(Name name)
        {
            Name = name;
        }
        public static Specie Create(string name) =>
            new(Name.Create(name));
        public void Rename(string newName)
        {
            Name = Name.Create(newName);
        }
    }
}
