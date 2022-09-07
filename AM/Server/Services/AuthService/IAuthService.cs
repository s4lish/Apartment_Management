namespace AM.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> GetLoginAdmin(UserLoginDto userDTO);

        Task<string> GetLoginUnit(UserLoginDto userDTO);

    }
}
