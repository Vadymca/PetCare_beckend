namespace PetCare.Domain.DomainServices
{
    // Інтерфейс для валідації мікрочіпів тварин.
    public interface IMicrochipValidator
    {
        // Перевіряє унікальність мікрочіпа.
        Task<bool> IsMicrochipUniqueAsync(string microchipId);

        // Перевіряє правильність формату мікрочіпа.
        bool IsValidFormat(string microchipId);
    }
}
