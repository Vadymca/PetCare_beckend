using NetTopologySuite.Geometries;
using PetCare.Domain.Common;
using PetCare.Domain.Enums;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Aggregates
{
    public sealed class LostPet : BaseEntity
    {
        public Slug Slug { get; private set; }
        public Guid UserId { get; private set; }
        public Guid? BreedId { get; private set; }
        public Name? Name { get; private set; }
        public string? Description { get; private set; }
        public Point? LastSeenLocation { get; private set; }
        public DateTime? LastSeenDate { get; private set; }
        public List<string> Photos { get; private set; } = new();
        public LostPetStatus Status { get; private set; }
        public string? AdminNotes { get; private set; }
        public float? Reward { get; private set; }
        public string? ContactAlternative {  get; private set; }
        public MicrochipId? MicrochipId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private LostPet() { }

        private LostPet(
            Slug slug,
            Guid userId,
            Guid? breedId,
            Name? name,
            string? description,
            Point? lastSeenLocation,
            DateTime? lastSeenDate,
            List<string>? photos,
            LostPetStatus status,
            string? adminNotes,
            float? reward,
            string? contactAlternative,
            MicrochipId? microchipId)
        {
            Slug = slug;
            UserId = userId;
            BreedId = breedId;
            Name = name;
            Description = description;
            LastSeenLocation = lastSeenLocation;
            LastSeenDate = lastSeenDate;
            Photos = photos ?? new List<string>();
            Status = status;
            AdminNotes = adminNotes;
            Reward = reward;
            ContactAlternative = contactAlternative;
            MicrochipId = microchipId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static LostPet Create(
            string slug,
            Guid userId,
            Guid? breedId,
            string? name,
            string? description,
            Point? lastSeenLocation,
            DateTime? lastSeenDate,
            List<string>? photos,
            LostPetStatus status,
            string? adminNotes,
            float? reward,
            string? contactAlternative,
            string?  microchipId)
        {
            return new LostPet(
                Slug.Create(slug),
                userId,
                breedId,
                string.IsNullOrWhiteSpace(name) ? null : Name.Create(name),
                description,
                lastSeenLocation,
                lastSeenDate,
                photos,
                status,
                adminNotes,
                reward,
                contactAlternative,
                microchipId is not null ? MicrochipId.Create(microchipId) : null
                );
        }

        public void UpdateStatus(LostPetStatus status, string? adminNotes = null)
        {
            Status = status;
            if (adminNotes != null)
                AdminNotes = adminNotes;

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
