using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Abstracts;

public interface IJwtService
{
    TokenResponseDto CreateJwtToken(User user);
}
