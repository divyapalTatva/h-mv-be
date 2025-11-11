using System.Data;

namespace MedVault.BE.Common.Constants
{
    public class SuccessMessage
    {
        public const string USER_REGISTERED = "User registered successfully. Please login to continue.";

        public const string LOGIN_SUCCESS = "Logged in successfully!";

        public const string LOGOUT_SUCCESS = "Logged out successfully!";

        public const string OTP_SENT = "OTP sent to your registered email. Please verify to continue.";

        public const string PATIENT_PROFILE_ADD_SUCCESS = "Patient profile added successfully!";

        public const string PATIENT_PROFILE_UPDATE_SUCCESS = "Patient profile updated successfully!";

        public const string DOCTOR_PROFILE_ADD_SUCCESS = "Doctor profile added successfully!";

        public const string DOCTOR_PROFILE_UPDATE_SUCCESS = "Doctor profile updated successfully!";
    }

    public static class ExceptionMessage
    {
        public const string VALIDATE_SORT_ORDER = "Sort order must be ascending or descending.";

        public const string VALIDATE_PHONE_NUMBER = "Please enter a valid contact number.";

        public const string VALIDATE_EMAIL = "Please enter a valid email.";

        public const string CUSTOM_API_EXCEPTION_MESSAGE = "An error occurred";

        public const string DATA_ALREADY_EXIST = "{0} already exists.";

        public const string UNREGISTERED_EMAIL = "The email address you entered does not exist.";

        public const string INCORRECT_PASSWORD = "The password you entered is incorrect.";

        public const string NOT_HAVING_PERMISSION_FOR_ROLE = "You do not have permission to login as {0}.";

        public const string INCORRECT_VERIFY_OTP_REQUEST = "The OTP verifaction request is incorrect, please try again.";

        public const string INCORRECT_OTP = "Invalid or expired OTP.";

        public const string UNREGISTERED_USER = "The user does not exist.";

        public const string UNREGISTERED_USER_PATIENT_PROFILE = "Failed to create patient profile because the associated user does not exist in the system.";

        public const string DATA_NOT_EXISTS = "{0} does not exist.";

        public const string ID_IS_NULL_OR_ZERO = "Id cannot be null or zero.";

        public const string USER_ROLE_NOT_AVAILABLE = "User role not available.";

        public const string INVALID_USER_ID = "Invalid user ID.";
    }
}
