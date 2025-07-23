using PetCare.Domain.Common;
using PetCare.Domain.Enums;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Aggregates
{
    public sealed class User : BaseEntity
    {
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public PhoneNumber Phone {  get; private set; }
        public UserRole Role { get; private set; }
        public Dictionary<string, string> Preferences { get; private set; }
        public int Points { get; private set; }
        public DateTime? LastLogin {  get; private set; }
        public string? ProfilePhoto {  get; private set; }
        public string Language {  get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private User() { }

        private User(
            Email email, 
            string passwordHash, 
            string firstName, 
            string lastName, 
            PhoneNumber phone, 
            UserRole role, 
            Dictionary<string, string> preferences, 
            int points, 
            DateTime? 
            lastLogin, 
            string? profilePhoto, 
            string language)
        {
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Role = role;
            Preferences = preferences ?? new();
            Points = points;
            LastLogin = lastLogin;
            ProfilePhoto = profilePhoto;
            Language = language;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static User Create(
            string email,
            string passwordHash,
            string firstName,
            string lastName,
            string phone,
            UserRole role,
            Dictionary<string, string>? preferences = null,
            int points = 0,
            DateTime? lastLogin = null,
            string? profilePhoto = null,
            string language = "uk")
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Хеш-пароль не може бути порожнім", nameof(passwordHash));

            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 50)
                throw new ArgumentException("Ім'я невірне", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 50)
                throw new ArgumentException("Прізвище невірне", nameof(lastName));

            if (string.IsNullOrWhiteSpace(language) || language.Length > 10)
                throw new ArgumentException("Мова невірна", nameof(language));

            if (points < 0)
                throw new ArgumentException("Бали не можуть бути від'ємними", nameof(points));

            return new User(
                Email.Create(email),
                passwordHash,
                firstName,
                lastName,
                PhoneNumber.Create(phone),
                role,
                preferences,
                points,
                lastLogin,
                profilePhoto,
                language);
        }

        public void UpdateProfile(
            string? firstName = null,
            string? lastName = null,
            string? phone = null,
            string? profilePhoto = null,
            string? language = null)
        {
            if (!string.IsNullOrWhiteSpace(firstName)) FirstName = firstName;
            if (!string.IsNullOrWhiteSpace(lastName)) LastName = lastName;
            if (!string.IsNullOrWhiteSpace(phone)) Phone = PhoneNumber.Create(phone);
            if (!string.IsNullOrWhiteSpace(profilePhoto)) ProfilePhoto = profilePhoto;
            if (!string.IsNullOrWhiteSpace(language)) Language = language;

            UpdatedAt = DateTime.UtcNow;
        }

        public void AddPoints(int amount)
        {
            if (amount < 0) return;
            Points += amount;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLastLogin(DateTime date)
        {
            LastLogin = date;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
