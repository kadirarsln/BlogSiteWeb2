namespace BlogSite.Models.Dtos.Tokens.Responses;

public sealed record TokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}
