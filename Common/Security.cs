using OtpNet;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Security
    {
        #region BCrypt Encryption
        public static string BCryptEncryption(string password)
        {
            password = password.Trim();
            if (string.IsNullOrEmpty(password)) { return password; }

            string salt = BCrypt.Net.BCrypt.GenerateSalt(10, 'b');
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public static bool BCryptVerify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        #endregion

        #region 2FA using TOTP
        public static string GenerateTotpSecretKey()
        {
            var key = KeyGeneration.GenerateRandomKey(20);
            return Base32Encoding.ToString(key);
        }

        public static string GenerateTotpQrCodeUri(string secretKey, string userEmail)
        {
            string issuer = "SmartInventory";
            string uri = $"otpauth://totp/{issuer}:{userEmail}?secret={secretKey}&issuer={issuer}&algorithm=SHA1&digits=6&period=30";

            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(uri, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new Base64QRCode(qrCodeData);
                return qrCode.GetGraphic(20);
            }
        }

        public static bool ValidateTotp(string secretKey, string userCode)
        {
            var totp = new Totp(Base32Encoding.ToBytes(secretKey));
            return totp.VerifyTotp(userCode, out long timeStepMatched, new VerificationWindow(2, 2));
        }
        #endregion
    }
}
