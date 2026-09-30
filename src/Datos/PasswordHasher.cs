using System;
using System.Security.Cryptography;

namespace Datos
{
    public static class PasswordHasher
    {
        private const int Iterations = 600000;
        public static string Hash(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 12 || password.Length > 128)
                throw new ArgumentException("La contraseña debe tener entre 12 y 128 caracteres.");
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(salt);
            using (var kdf = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                return "PBKDF2-SHA256$" + Iterations + "$" + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(kdf.GetBytes(32));
        }
        public static bool Verify(string password, string stored)
        {
            if (password == null || password.Length > 128 || string.IsNullOrEmpty(stored)) return false;
            var parts = stored.Split('$');
            int iterations;
            if (parts.Length != 4 || parts[0] != "PBKDF2-SHA256" || !int.TryParse(parts[1], out iterations)
                || iterations < Iterations || iterations > 2000000) return false;
            try
            {
                var salt = Convert.FromBase64String(parts[2]);
                var expected = Convert.FromBase64String(parts[3]);
                if (salt.Length != 16 || expected.Length != 32) return false;
                using (var kdf = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
                {
                    var actual = kdf.GetBytes(32);
                    int difference = 0;
                    for (int i = 0; i < expected.Length; i++) difference |= expected[i] ^ actual[i];
                    return difference == 0;
                }
            }
            catch (FormatException) { return false; }
        }
    }
}
