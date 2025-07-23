namespace PetCare.Domain.DomainServices
{
    // Інтерфейс для надсилання нотифікацій користувачам.
    public interface INotificationDispatcher
    {
        Task SendAsync(
            Guid userId,
            string title,
            string message,
            string? notifiableEntity = null,
            Guid? notifiableEntityId = null);
    }
}
