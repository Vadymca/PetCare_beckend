using PetCare.Domain.Common;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Entities
{
    public sealed class PaymentMethod : BaseEntity
    {
        public Name Name { get; private set; }

        private PaymentMethod() { }

        private PaymentMethod(Name name) 
        {
            Name = name;
        }

        public static PaymentMethod Create(Name name)
        {
            return new PaymentMethod(name);
        }

        public void Rename(string newName)
        {
            Name = Name.Create(newName);
        }
    }
}
