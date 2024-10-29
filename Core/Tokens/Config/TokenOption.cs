
namespace Core.Tokens.Config;

public class TokenOption
{
    public string Issuer { get; set; }
    public List<string> Audience { get; set; }
    public int AccesTokenExpiration { get; set; }
    public string SecurityKey { get; set; }
}
