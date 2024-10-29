namespace BlogSite.Models.Dtos.Posts.Responses;

public sealed record PostResponseDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime CreatedDate { get; init; }
    public string Username { get; init; }
    public string CategoryName{ get; init; }
}
