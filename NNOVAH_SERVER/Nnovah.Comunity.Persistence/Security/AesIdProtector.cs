using Nnovah.Comunity.Application.Contracts.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Persistence.Security
{
    public class AesIdProtector : IIdProtector
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;
        public AesIdProtector(string secretKey)
        {
        
            _key = Encoding.UTF8.GetBytes(secretKey.PadRight(32).Substring(0, 32));
            _iv = new byte[16];
        }

        public string Encrypt(int id)
        {
            var idBytes = BitConverter.GetBytes(id);

            // IV aleatório para AES
            byte[] iv = RandomNumberGenerator.GetBytes(16);

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var encryptedBytes = aes.CreateEncryptor().TransformFinalBlock(idBytes, 0, idBytes.Length);

            // Combina IV + Encrypted + HMAC
            var combined = new byte[iv.Length + encryptedBytes.Length];
            Buffer.BlockCopy(iv, 0, combined, 0, iv.Length);
            Buffer.BlockCopy(encryptedBytes, 0, combined, iv.Length, encryptedBytes.Length);

            // Cria HMAC
            using var hmac = new HMACSHA256(_key);
            var mac = hmac.ComputeHash(combined);

            // Final = IV + Encrypted + HMAC
            var finalBytes = new byte[combined.Length + mac.Length];
            Buffer.BlockCopy(combined, 0, finalBytes, 0, combined.Length);
            Buffer.BlockCopy(mac, 0, finalBytes, combined.Length, mac.Length);

            return Convert.ToHexString(finalBytes); // saída longa (~96+ caracteres)
        }

        public int Decrypt(string encryptedId)
        {
            var allBytes = Convert.FromHexString(encryptedId);

            // Separa IV+Encrypted e HMAC
            var macLength = 32; // HMACSHA256 = 32 bytes
            var combinedLength = allBytes.Length - macLength;

            var combined = new byte[combinedLength];
            var mac = new byte[macLength];

            Buffer.BlockCopy(allBytes, 0, combined, 0, combinedLength);
            Buffer.BlockCopy(allBytes, combinedLength, mac, 0, macLength);

            // Verifica HMAC
            using var hmac = new HMACSHA256(_key);
            var expectedMac = hmac.ComputeHash(combined);

            if (!CryptographicOperations.FixedTimeEquals(mac, expectedMac))
                throw new CryptographicException("EncryptedId inválido ou corrompido.");

            // Recupera IV e Encrypted
            var iv = new byte[16];
            Buffer.BlockCopy(combined, 0, iv, 0, 16);

            var encryptedBytes = new byte[combined.Length - 16];
            Buffer.BlockCopy(combined, 16, encryptedBytes, 0, encryptedBytes.Length);

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var decryptedBytes = aes.CreateDecryptor().TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return BitConverter.ToInt32(decryptedBytes);
        }
    }
}
