using System;
using Xunit;
using TugasBesar.Core.Security;

namespace UnitTesting
{
    public class PasswordHasherTests
    {
        [Fact]
        public void HashPassword_ShouldReturnNonEmptyString()
        {
            // Arrange
            string password = "MySecurePassword123";

            // Act
            string hash = PasswordHasher.HashPassword(password);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(hash));
            Assert.NotEqual(password, hash);
        }

        [Fact]
        public void VerifyPassword_WithCorrectPassword_ShouldReturnTrue()
        {
            // Arrange
            string password = "MySecurePassword123";
            string hash = PasswordHasher.HashPassword(password);

            // Act
            bool isValid = PasswordHasher.VerifyPassword(hash, password);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void VerifyPassword_WithIncorrectPassword_ShouldReturnFalse()
        {
            // Arrange
            string password = "MySecurePassword123";
            string incorrectPassword = "WrongPassword123";
            string hash = PasswordHasher.HashPassword(password);

            // Act
            bool isValid = PasswordHasher.VerifyPassword(hash, incorrectPassword);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void VerifyPassword_WithNullOrInvalidHash_ShouldReturnFalse()
        {
            // Arrange
            string password = "MySecurePassword123";

            // Act & Assert
            Assert.False(PasswordHasher.VerifyPassword("invalid_hash_string", password));
        }

        [Fact]
        public void HashPassword_SamePasswordShouldHaveDifferentHashesDueToSalt()
        {
            // Arrange
            string password = "MySecurePassword123";

            // Act
            string hash1 = PasswordHasher.HashPassword(password);
            string hash2 = PasswordHasher.HashPassword(password);

            // Assert
            Assert.NotEqual(hash1, hash2); // hashes should be different because of random salt
            Assert.True(PasswordHasher.VerifyPassword(hash1, password));
            Assert.True(PasswordHasher.VerifyPassword(hash2, password));
        }
    }
}
