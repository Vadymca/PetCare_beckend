namespace PetCare.Domain.DomainServices
{
    // Інтерфейс для обробки платежів.
    public interface IPaymentProcessor
    {
        // Ініціює платіж.
        Task<string> ProcessPaymentAsync(Guid userId, decimal amount, string description);

        // Перевіряє статус платежу.
        Task<bool> IsPaymentSuccessfulAsync(string paymentId);
    }
}
