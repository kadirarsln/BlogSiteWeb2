using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogSite.Service.Concretes;

public sealed class JwtService : IJwtService
{
    public TokenResponseDto CreateJwtToken(User user)
    {
        throw new NotImplementedException();
    }

    public List<Claim> GetClaims(User user , List<string> audiences)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim("email",user.Email),                      //Custom yazabiliriz.
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim("Parlayan_ve_kayan_yıldılar","Talhişko")
        };

        claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
        return claims;
    }
}
