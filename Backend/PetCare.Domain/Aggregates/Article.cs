using PetCare.Domain.Common;
using PetCare.Domain.ValueObjects;
using PetCare.Domain.Enums;

namespace PetCare.Domain.Aggregates
{
    public sealed class Article : BaseEntity
    {
        public Title Title { get; private set; }
        public string Content { get; private set; }
        public Guid? CategoryId { get; private set; }
        public Guid? AuthorId { get; private set; }
        public ArticleStatus Status { get; private set; }
        public string? Thumbnail { get; private set; }
        public DateTime PublishedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Article() { }

        private Article(
            Title title,
            string content,
            Guid? categoryId,
            Guid? authorId,
            ArticleStatus status,
            string? thumbnail,
            DateTime publishedAt,
            DateTime updatedAt)
        {
            Title = title;
            Content = content;
            CategoryId = categoryId;
            AuthorId = authorId;
            Status = status;
            Thumbnail = thumbnail;
            PublishedAt = publishedAt;
            UpdatedAt = updatedAt;
        }

        public static Article Create(
            string title,
            string content,
            Guid? categoryId,
            Guid? authorId,
            ArticleStatus status,
            string? thumbnail = null)
        {
            var now = DateTime.UtcNow;
            return new Article(
                Title.Create(title),
                content,
                categoryId,
                authorId,
                status,
                thumbnail,
                publishedAt: now,
                updatedAt: now);
        }

        public void Update(
            string? title = null,
            string? content = null,
            Guid? categoryId = null,
            ArticleStatus? status = null,
            string? thumbnail = null)
        {
            if (title is not null) Title = Title.Create(title);
            if (content is not null) Content = content;
            if (categoryId is not null) CategoryId = categoryId;
            if (status is not null) Status = status.Value;
            if (thumbnail is not null) Thumbnail = thumbnail;

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
