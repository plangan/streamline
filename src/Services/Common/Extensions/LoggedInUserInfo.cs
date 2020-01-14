using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Common.Extensions
{
    public static class LoggedInUserInfo
    {
        public static int GetPersonId(this IEnumerable<Claim> claims)
        {
            int.TryParse(claims.FirstOrDefault(c => c.Type == AppClaimTypes.PersonId)?.Value, out var result);
            return result;
        }
    }
}