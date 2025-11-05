namespace MedVault.BE.Common.Helpers
{
    public class EncryptionHelper
    {
        public static string Base64Encode(string plaintText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plaintText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string cipherText)
        {
            var base64EncodedBytes = Convert.FromBase64String(cipherText);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
