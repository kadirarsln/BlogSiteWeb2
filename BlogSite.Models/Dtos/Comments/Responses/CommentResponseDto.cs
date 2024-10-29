namespace BlogSite.Models.Dtos.Comments.Responses;

public sealed record CommentResponseDto
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public DateTime CreatedDate { get; init; }
    public string Username { get; init; }
    public string PostTitle { get; init; }
}
