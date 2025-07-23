using PetCare.Domain.Common;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Aggregates
{
    public sealed class SuccessStory : BaseEntity
    {
        public Guid AnimalId { get; private set; }
        public Guid? UserId { get; private set; }
        public Title Title { get; private set; }
        public string Content { get; private set; }
        public List<string> Photos { get; private set; } = new();
        public List<string> Videos { get; private set; } = new();
        public DateTime PublishedAt { get; private set; }
        public int Views { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private SuccessStory() { }

        private SuccessStory(
            Guid animalId,
            Guid? userId,
            Title title,
            string content,
            List<string>? photos,
            List<string>? videos)
        {
            if (animalId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор тварини не може бути порожнім.", nameof(animalId));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Контент обов'язковий.", nameof(content));

            AnimalId = animalId;
            UserId = userId;
            Title = title;
            Content = content;
            Photos = photos ?? new List<string>();
            Videos = videos ?? new List<string>();
            Views = 0;
            PublishedAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static SuccessStory Create(
            Guid animalId,
            Guid? userId,
            string title,
            string content,
            List<string>? photos = null,
            List<string>? videos = null)
        {
            return new SuccessStory(
                animalId,
                userId,
                Title.Create(title),
                content,
                photos,
                videos);
        }

        public void IncrementViews()
        {
            Views++;
        }

        public void Update(
            string? title = null,
            string? content = null,
            List<string>? photos = null,
            List<string>? videos = null)
        {
            if (title is not null)
                Title = Title.Create(title);

            if (content is not null)
                Content = content;

            if (photos is not null)
                Photos = photos;

            if (videos is not null)
                Videos = videos;

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
