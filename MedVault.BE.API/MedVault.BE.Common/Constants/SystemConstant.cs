namespace MedVault.BE.Common.Constants
{
    public static class SystemConstant
    {
        public const string CORS_POLICY_NAME = "MedVaultCorsPolicy";

        public const string CONNECTION_STRING_NAME = "MedVaultDBConnection";

        public const string CURRENT_UTC_DATETIME = "(getutcdate())";

        public const string APPLICATION_JSON = "application/json";

        public const string JWT_AUTHKEY = "JWT:AuthKey";

        public const string JWT_ACCESS_TOKEN_VALIDITY_IN_MINUTES = "JWT:AccessTokenValidityInMinutes";


        #region page list
        public const string ASCENDING = "ascending";

        public const string DESCENDING = "descending";

        public const int DEFAULT_PAGE_SIZE = 10;

        public const string DEFAULT_SORT_COLUMN = "id";
        #endregion
    }

    public static class ExtraClaimType
    {
        public const string IsProfileFilled = "ipf";
    }
}
