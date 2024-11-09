
namespace BlogSite.Models.Dtos.Posts.Requests;

public sealed record CreatePostRequest(string Title, string Content, int CategoryId);
