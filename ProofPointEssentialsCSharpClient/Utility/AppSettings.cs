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

        internal static string ProofPoint_password => ConfigurationManager.AppSettings["ProofPointEssentials:Password"].ToString();

        internal static string ProofPoint_BaseUrl => ConfigurationManager.AppSettings["ProofPointEssentials:Base"].ToString().EnsureEndsWith("/");
    }
}