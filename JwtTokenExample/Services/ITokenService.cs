namespace JwtTokenExample.Services
{
    public interface ITokenService
    {
        string GetToken(UserLogins user);
    }
}
