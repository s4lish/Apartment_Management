namespace AM.Client.Services.LoginService
{
    public interface ILoginHttpService
    {
        Task<bool> LoginAsync(UserLoginDto user);
    }
}
