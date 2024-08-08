
namespace PortfolioSiteApi.Tools
{
    public static class Encrypter
    {
        public static string GeneratePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool CheckPassword(string passwordInput, string passwordDb)
        {
            return BCrypt.Net.BCrypt.Verify(passwordInput,passwordDb);
        }
    }
}