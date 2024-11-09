using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Tokens.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogSite.Service.Concretes;

public sealed class JwtService : IJwtService
{

    private readonly TokenOption _tokenOption;
    private readonly UserManager<User> _userManager;

    public JwtService(IOptions<TokenOption> tokenOption, UserManager<User> userManager)
    {
        _tokenOption = tokenOption.Value;
        _userManager = userManager;
    }

    public async Task<TokenResponseDto> CreateJwtTokenAsync(User user)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccesTokenExpiration);
        var secretKey = SecurityKeyHelper.GetSecurityKey(_tokenOption.SecurityKey);

        SigningCredentials sc = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenOption.Issuer,
            claims: await GetClaimsAsync(user, _tokenOption.Audience),
            expires: accessTokenExpiration,
            signingCredentials: sc
            );

        var handler = new JwtSecurityTokenHandler();
        string token = handler.WriteToken(jwtSecurityToken);

        return new TokenResponseDto
        {
            AccessToken = token,
            AccessTokenExpiration = accessTokenExpiration,
        };
    }

    public async Task<List<Claim>> GetClaimsAsync(User user, List<string> audiences)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim("email",user.Email),                      //Custom yazabiliriz.
            new Claim(ClaimTypes.Name,user.UserName),
        };

        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Count > 0)
        {
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
        }

        claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
        return claims;
    }
}
