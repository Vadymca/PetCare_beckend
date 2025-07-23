using PetCare.Domain.Common;
using PetCare.Domain.Enums;

namespace PetCare.Domain.Aggregates
{
    public sealed class IoTDevice : BaseEntity
    {
        public Guid ShelterId { get; private set; }
        public IoTDeviceType Type { get; private set; }
        public string Name { get; private set; } = default!;
        public IoTDeviceStatus Status { get; private set; }
        public Dictionary<string, object>? Data { get; private set; }
        public string SerialNumber { get; private set; } = default!;
        public Dictionary<string, object>? AlertThresholds { get; private set; }
        public DateTime LastUpdated { get; private set; }

        private IoTDevice() { }

        private IoTDevice(
            Guid shelterId,
            IoTDeviceType type,
            string name,
            IoTDeviceStatus status,
            string serialNumber,
            Dictionary<string, object>? data,
            Dictionary<string, object>? alertThresholds)
        {
            if (shelterId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор притулку не може бути порожнім.", nameof(shelterId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва не може бути пустою.", nameof(name));

            if (string.IsNullOrWhiteSpace(serialNumber))
                throw new ArgumentException("Серійний номер не може бути порожнім.", nameof(serialNumber));

            ShelterId = shelterId;
            Type = type;
            Name = name;
            Status = status;
            SerialNumber = serialNumber;
            Data = data;
            AlertThresholds = alertThresholds;
            LastUpdated = DateTime.UtcNow;
        }

        public static IoTDevice Create(
            Guid shelterId,
            IoTDeviceType type,
            string name,
            IoTDeviceStatus status,
            string serialNumber,
            Dictionary<string, object>? data = null,
            Dictionary<string, object>? alertThresholds = null)
        {
            return new IoTDevice(
                shelterId,
                type,
                name,
                status,
                serialNumber,
                data,
                alertThresholds
            );
        }

        public void UpdateData(Dictionary<string, object> newData)
        {
            Data = newData;
            LastUpdated = DateTime.UtcNow;
        }

        public void UpdateStatus(IoTDeviceStatus status)
        {
            Status = status;
            LastUpdated = DateTime.UtcNow;
        }

        public void UpdateThresholds(Dictionary<string, object> thresholds)
        {
            AlertThresholds = thresholds;
            LastUpdated = DateTime.UtcNow;
        }

    }
}
