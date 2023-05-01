using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FinanceTracker
{
    public class AuthOptions
    {
        public const string ISSUER = "FinanceTrackerServer";
        public const string AUDIENCE = "FinanceTrackerClient";
        public const int LIFETIME = 60;
        const string KEY = "vbXSZTqV2+K1vckHeVmm/W8n8W4GzTwr6nQHWKhtROCwBLkwxd3Rpig0o8i3Pyr0";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
