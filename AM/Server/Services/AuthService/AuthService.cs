namespace AM.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly ApartmentDB _db;
        private readonly IPublicService _pb;

        public AuthService(ApartmentDB db,IPublicService pb)
        {
            _db = db;
            _pb = pb;
        }


        public async Task<string> GetLoginAdmin(UserLoginDto userDTO)
        {

            var us = await _db.User.Where(x => x.Username == userDTO.UserName && !x.IsDelete).FirstOrDefaultAsync();
            
            if(us == null)
            {
                return "201";
            }

            if (us.IsLocked)
            {
                return "202";
            }

            if (!_pb.VerifyPasswordHash(userDTO.Password, us.PasswordHash, us.PasswordSalt))
            {

                return "203";
            }
            string token = _pb.CreateToken(us.Username, us.Id,"Admin",24);
            return token;
        }


        public async Task<string> GetLoginUnit(UserLoginDto userDTO)
        {
            var us = await _db.UnitInfo.Where(x => (x.MalekIsThere && x.MobileMalek == userDTO.UserName) || (!x.MalekIsThere && x.MobileMostajer == userDTO.UserName)).FirstOrDefaultAsync();
            
            if (us == null)
            {
                return "201";
            }

            if (!us.isActive)
            {
                return "202";
            }

            if (us.Password != userDTO.Password)
            {
                return "203";
            }

            string token = _pb.CreateToken(us.NumberUnit, us.Id,"Unit", 24000);
            return token;
        }
    }
}
