namespace MedVault.BE.Common.Enums
{
    public class Enums
    {
        public enum UserRole
        {
            Admin = 1,
            Doctor = 2,
            User = 3
        }

        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 3
        }

        public enum BloodGroup
        {
            APositive = 1,
            ANegative = 2,
            BPositive = 3,
            BNegative = 4,
            OPositive = 5,
            ONegative = 6,
            ABPositive = 7, 
            ABNegative = 8
        }

        public enum ReminderType
        {
            LabTest = 1, 
            Appointment = 2, 
            Medicine = 3
        }
    }
}
