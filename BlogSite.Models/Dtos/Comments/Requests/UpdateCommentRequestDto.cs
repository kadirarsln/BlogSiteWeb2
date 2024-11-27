namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record UpdateCommentRequestDto(Guid Id, string Text);

