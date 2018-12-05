using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Utility
{
    internal static class AppSettings
    {
        internal static string ProofPoint_user => ConfigurationManager.AppSettings["ProofPointEssentials:Username"].ToString();

        internal static string ProofPoint_password
        {
            get
            {
                string hash = ConfigurationManager.AppSettings["ProofPointEssentials:PasswordHash"].ToString();
                if (!hash.IsNullOrEmpty())
                {
                    return EncryptionHelper.Decrypt(hash);
                }
                else
                {
                    return ConfigurationManager.AppSettings["ProofPointEssentials:Password"].ToString();
                }
            }
        }

        internal static string ProofPoint_BaseUrl => ConfigurationManager.AppSettings["ProofPointEssentials:Base"].ToString().EnsureEndsWith("/");

        internal static string ProofPoint_Logs => ConfigurationManager.AppSettings["ProofPointEssentials:Logs"].ToString().Trim();
    }
}