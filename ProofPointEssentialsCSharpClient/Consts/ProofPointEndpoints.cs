using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Consts
{
    internal static class ProofPointEndpoints
    {
        internal static string GetUserEndpoint(string Domain, string UserEmail)
        {
            return $"orgs/{Domain}/users/{UserEmail}";
        }

        internal static string GetUsersEndpoint(string Domain)
        {
            return $"orgs/{Domain}/users";
        }

        internal static string UpdateUserEndpoint(string Domain, string UserEmail)
        {
            return $"orgs/{Domain}/users/{UserEmail}";
        }

        internal static string DeleteUserEndpoint(string Domain, string UserEmail)
        {
            return $"orgs/{Domain}/users/{UserEmail}";
        }

        internal static string CreateUserEndpoint(string Domain)
        {
            return $"orgs/{Domain}/users";
        }
    }
}