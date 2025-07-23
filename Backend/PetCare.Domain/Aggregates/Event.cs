using PetCare.Domain.Common;
using PetCare.Domain.Enums;
using NetTopologySuite.Geometries;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Aggregates
{
    public sealed class Event : BaseEntity
    {
        public Guid? ShelterId { get; private set; }
        public Title Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime? EventDate { get; private set; }
        public Point? Location { get; private set; }
        public Address? Address { get; private set; }
        public EventType Type { get; private set; }
        public EventStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Event() { }

        private Event(
            Guid? shelterId,
            Title title,
            string? description,
            DateTime? eventDate,
            Point? location,
            Address? address,
            EventType type,
            EventStatus status)
        {
            ShelterId = shelterId;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description;
            EventDate = eventDate;
            Location = location;
            Address = address;
            Type = type;
            Status = status;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Event Create(
            Guid? shelterId,
            string title,
            string? description,
            DateTime? eventDate,
            Point? location,
            string? address,
            EventType type,
            EventStatus status)
        {
            return new Event(
                shelterId,
                Title.Create(title),
                description, 
                eventDate, 
                location,
                address is not null ? Address.Create(address) : null,
                type, 
                status);
        }

        public void Update(
            string? title = null,
            string? description = null,
            DateTime? eventDate = null,
            Point? location = null,
            string? address = null,
            EventStatus? status = null)
        {
            if (!string.IsNullOrWhiteSpace(title))
                Title = Title.Create(title);

            if (description is not null)
                Description = description;

            if (eventDate is not null)
                EventDate = eventDate;

            if (location is not null)
                Location = location;

            if (address is not null)
                Address = Address.Create(address);

            if (status is not null)
                Status = status.Value;

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
