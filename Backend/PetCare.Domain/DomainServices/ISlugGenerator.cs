namespace PetCare.Domain.DomainServices
{
    // Інтерфейс для генерації унікальних слагів для сутностей.
    public interface ISlugGenerator
    {
        //Генерує унікальний слаг для заданого тексту в межах певного типу сутності.
        Task<string> GenerateSlugAsync(string input, string entityType);
    }
}
