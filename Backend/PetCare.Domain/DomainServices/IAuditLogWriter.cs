using Newtonsoft.Json.Linq;

namespace PetCare.Domain.DomainServices
{
    // Інтерфейс для запису дій у журнал аудиту.
    public interface IAuditLogWriter
    {
        // Записує зміну у системі.
        Task WriteAsync(
            string tableName,
            Guid recordId,
            string operation,
            Guid? userId,
            JObject changes);
    }
}

