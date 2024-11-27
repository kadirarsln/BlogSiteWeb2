namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequestDto(string Text, Guid PostId);

