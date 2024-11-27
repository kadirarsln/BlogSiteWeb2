namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record UpdateCommentByPostRequestDto(Guid Id, string Text, Guid PostId);

