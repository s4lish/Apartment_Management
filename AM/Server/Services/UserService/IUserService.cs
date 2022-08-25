namespace AM.Server.Services.UserService
{
    public interface IUserService
    {
        Task<bool> CheckUserIs();
        Task<bool> CreateAdmin(UserDto userDto);
    }
}
