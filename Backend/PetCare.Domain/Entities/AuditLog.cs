using PetCare.Domain.Common;
using PetCare.Domain.Enums;

namespace PetCare.Domain.Entities
{
    public sealed class AuditLog : BaseEntity
    {
        public string TableName { get; private set; } = null!;
        public Guid RecordId { get; private set; }
        public AuditOperation Operation { get; private set; }
        public Guid? UserId { get; private set; }
        public string? Changes { get; private set; } 
        public DateTime CreatedAt { get; private set; }

        private AuditLog() { }

        private AuditLog(
            string tableName,
            Guid recordId,
            AuditOperation operation,
            Guid? userId,
            string? changes)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentException("Назва таблиці не може бути порожньою.", nameof(tableName));

            if (recordId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор запису не може бути порожнім.", nameof(recordId));

            TableName = tableName;
            RecordId = recordId;
            Operation = operation;
            UserId = userId;
            Changes = changes;
            CreatedAt = DateTime.UtcNow;
        }

        public static AuditLog Create(
            string tableName,
            Guid recordId,
            AuditOperation operation,
            Guid? userId,
            string? changes)
        {
            return new AuditLog(
                tableName, 
                recordId, 
                operation, 
                userId, 
                changes);
        }
    }
}
