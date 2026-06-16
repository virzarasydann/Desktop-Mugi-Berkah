using System;
using System.Security.Cryptography;

namespace TugasBesar.Core.Security
{
    /// <summary>
    /// Utilitas keamanan untuk hashing dan verifikasi kata sandi menggunakan algoritma PBKDF2 (SHA256).
    /// </summary>
    public static class PasswordHasher
    {
        private const int SaltSize = 16; // 128-bit salt
        private const int KeySize = 32;  // 256-bit subkey
        private const int Iterations = 10000; // Jumlah iterasi PBKDF2

        /// <summary>
        /// Membuat hash kriptografi yang aman dari kata sandi biasa.
        /// </summary>
        /// <param name="password">Kata sandi biasa.</param>
        /// <returns>String ter-hash berformat Base64 yang mencakup salt.</returns>
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var key = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                KeySize);

            var hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(key, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Memverifikasi kecocokan antara kata sandi biasa dengan string hash tersimpan.
        /// </summary>
        /// <param name="hashedPassword">String hash dari database.</param>
        /// <param name="password">Kata sandi biasa yang diuji.</param>
        /// <returns>True jika cocok, False jika tidak cocok atau terjadi kesalahan format.</returns>
        public static bool VerifyPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null) throw new ArgumentNullException(nameof(hashedPassword));
            if (password == null) throw new ArgumentNullException(nameof(password));

            try
            {
                var hashBytes = Convert.FromBase64String(hashedPassword);
                if (hashBytes.Length != SaltSize + KeySize) return false;

                var salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);

                var key = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    Iterations,
                    HashAlgorithmName.SHA256,
                    KeySize);

                // Perbandingan konstan waktu untuk mencegah timing attack
                var diff = 0;
                for (int i = 0; i < KeySize; i++)
                {
                    diff |= hashBytes[i + SaltSize] ^ key[i];
                }
                return diff == 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
