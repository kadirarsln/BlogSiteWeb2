namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequest(string Text, Guid PostId, long UserId);

