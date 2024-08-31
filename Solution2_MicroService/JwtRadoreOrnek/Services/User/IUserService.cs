namespace JwtRadoreOrnek.Services.User
{
    public interface IUserService
    {
        (string userName, string token)? Authenticate(string userName, string password);
    }
}