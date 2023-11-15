using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MyPortfolio.Core.Helpers.PasswordHasher;

public class PasswordHash : IPasswordHash
{
    public string EncryptPassword(string password, byte[] salt)
    {
        byte[] byteArray = { 4, 1, 12 };
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: byteArray,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 1000000,
            numBytesRequested: 256 / 8));
    }
}
