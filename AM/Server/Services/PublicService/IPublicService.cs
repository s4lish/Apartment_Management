namespace AM.Server.Services.PublicService
{
    public interface IPublicService
    {
        bool VerifyPasswordHash(string password, byte[] hash, byte[] salt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        string CreateToken(string user, int Id, int min);

    }
}
