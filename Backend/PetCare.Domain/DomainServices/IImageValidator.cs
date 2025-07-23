namespace PetCare.Domain.DomainServices
{
    // Інтерфейс для валідації зображень перед збереженням/обробкою.
    public interface IImageValidator
    {
        // Перевіряє чи зображення відповідає дозволеним розмірам і формату.
        bool IsValid(byte[] imageBytes, string fileName);

        // Повертає список помилок, якщо валідація не пройдена.
        IReadOnlyCollection<string> GetValidationErrors(byte[] imageBytes, string fileName);
    }
}
