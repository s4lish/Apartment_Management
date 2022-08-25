using AM.Shared.ViewModel;

namespace AM.Client.Services.UserService
{
    public interface IUserHttpService
    {
        Task<bool?> CheckUserIs();

        Task<bool> CreateAdminUser(UserDto newUser);

    }
}
