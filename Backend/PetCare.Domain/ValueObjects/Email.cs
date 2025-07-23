using PetCare.Domain.Common;
using System.Text.RegularExpressions;

namespace PetCare.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        private static readonly Regex _regex = new(@"^[\w\.\-]+@([\w\-]+\.)+[\w\-]{2,4}$", RegexOptions.Compiled);
        public string Value { get; }

        private Email(string value) => Value = value;

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !_regex.IsMatch(email))
                throw new ArgumentException("Неправильний формат електронної пошти.", nameof(email));
            return new Email(email);
        }
        protected override IEnumerable<object> GetEqualityComponents() => new[] { Value };
        public override string ToString() => Value;
    }
}
