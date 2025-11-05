namespace MedVault.BE.Common.Constants
{
    public static class ValidationConstants
    {
        #region Common
        public const string EMAIL_REGEX = @"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[a-zA-Z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?";

        public const string SORT_ORDER_REGEX = $"^({SystemConstant.ASCENDING}|{SystemConstant.DESCENDING})$";

        public const string PHONE_NUMBER_REGEX = @"^[6-9]\d{9}$";

        public const string NAME_REGEX = @"^[a-zA-Z\s\-]+$";
        #endregion

        #region Authentication

        #endregion
    }
}
