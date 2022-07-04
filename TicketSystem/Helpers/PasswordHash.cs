namespace TicketSystem.Helpers
{
    public static class PasswordHash
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }
        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(inputPassword, hashedPassword);
        }

    }
}
