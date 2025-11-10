using System.Security.Claims;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Common.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            if (user?.Identity is ClaimsIdentity identity)
            {
                var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                    return userId;
            }
            return null; // Return null if user ID claim is not found or cannot be parsed
        }

        public static UserRole? GetUserRole(this ClaimsPrincipal user)
        {
            if (user?.Identity is ClaimsIdentity identity)
            {
                var userRoleClaim = identity.FindFirst(ClaimTypes.Role);
                if (!string.IsNullOrWhiteSpace(userRoleClaim?.Value) &&
                    Enum.TryParse<UserRole>(userRoleClaim.Value, out var role))
                {
                    return role;
                }
            }

            return null; // Return null if user role claim is not found or invalid
        }

    }
}
