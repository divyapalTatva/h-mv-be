namespace MedVault.BE.Common.Helpers
{
    public static class OtpHelper
    {
        private static readonly Random _random = new Random();

        public static string GenerateOtp()
        {
            return _random.Next(100000, 999999).ToString();
        }
    }
}
