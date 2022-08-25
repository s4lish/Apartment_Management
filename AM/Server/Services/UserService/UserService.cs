using AM.Server.Data.DataModel;

namespace AM.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApartmentDB _db;
        private readonly IMapper _mapper;
        private readonly IPublicService _pb;

        public UserService(ApartmentDB db, IMapper mapper, IPublicService pb)
        {
            _db = db;
            _mapper = mapper;
            _pb = pb;
        }

        public async Task<bool> CheckUserIs()
        {
            var check = await _db.User.AnyAsync();

            return check;
        }

        public async Task<bool> CreateAdmin(UserDto userDto)
        {
            _pb.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] salt);

            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = salt;
            _db.User.Add(user);
           var check = await _db.SaveChangesAsync();

            return check > 0 ? true : false;

        }
    }
}
