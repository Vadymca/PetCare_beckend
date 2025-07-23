using PetCare.Domain.Common;

namespace PetCare.Domain.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public string Value { get; }
        private Name(string value) => Value = value;

        public static Name Create(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ім'я не може бути порожнім.", nameof(value));
            return new Name(value);
        }
        protected override IEnumerable<object> GetEqualityComponents() => new[] { Value };
        public override string ToString() => Value;
    }
}
