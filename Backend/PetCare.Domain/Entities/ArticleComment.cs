using PetCare.Domain.Common;
using PetCare.Domain.Enums;

namespace PetCare.Domain.Entities
{
    public sealed class ArticleComment : BaseEntity
    {
        public Guid ArticleId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid? ParentCommentId { get; private set; }
        public string Content { get; private set; }
        public int Likes { get; private set; }
        public CommentStatus Status { get; private set; }
        public Guid? ModeratedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private ArticleComment() { }

        private ArticleComment(
            Guid articleId,
            Guid userId,
            Guid? parentCommentId,
            string content,
            CommentStatus status,
            Guid? moderatedBy,
            DateTime createdAt,
            DateTime updatedAt)
        {
            if (articleId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор статті не може бути порожнім.", nameof(articleId));
            if (userId == Guid.Empty)
                throw new ArgumentException("Ідентифікатор користувача не може бути порожнім.", nameof(userId));
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Вміст не може бути порожнім.", nameof(content));

            ArticleId = articleId;
            UserId = userId;
            ParentCommentId = parentCommentId;
            Content = content;
            Likes = 0;
            Status = status;
            ModeratedBy = moderatedBy;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static ArticleComment Create(
            Guid articleId,
            Guid userId,
            string content,
            Guid? parentCommentId = null)
        {
            return new ArticleComment(
                articleId,
                userId,
                parentCommentId,
                content,
                CommentStatus.Pending,
                null,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public void UpdateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Вміст не може бути порожнім.", nameof(content));

            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetStatus(CommentStatus status, Guid? moderatedBy)
        {
            Status = status;
            ModeratedBy = moderatedBy;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddLike()
        {
            Likes++;
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveLike()
        {
            if (Likes > 0)
            {
                Likes--;
                UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
