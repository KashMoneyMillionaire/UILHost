using System;
using System.Security.Cryptography;
using System.Text;

namespace UILHost.Infrastructure
{
    public sealed class SaltedHash
    {
        private const int SALT_LENGTH = 24;

        public string Salt { get; private set; }
        public string Hash { get; private set; }

        public SaltedHash(string data)
        {
            Salt = CreateSalt();
            Hash = CalculateHash(Salt, data);
        }

        public SaltedHash(string salt, string hash)
        {
            Salt = salt;
            Hash = hash;
        }

        public bool Verify(string data)
        {
            return Hash.Equals(CalculateHash(Salt, data));
        }

        #region HELPER LOGIC

        private static string CreateSalt()
        {
            var random = CreateRandomBytes(SALT_LENGTH);
            return Convert.ToBase64String(random).Substring(0, SALT_LENGTH);
        }

        private static byte[] CreateRandomBytes(int length)
        {
            var random = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(random);
            return random;
        }

        private string CalculateHash(string salt, string password)
        {
            var data = ToByteArray(salt + password);
            var hash = CalculateHash(data);
            return Convert.ToBase64String(hash);
        }

        private static byte[] CalculateHash(byte[] data)
        {
            return new SHA256CryptoServiceProvider().ComputeHash(data);
        }

        private static byte[] ToByteArray(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        #endregion

    }
}
