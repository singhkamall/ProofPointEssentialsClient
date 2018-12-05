using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Utility
{
    public static class RestSharpExtensions
    {
        public static RestRequest AddAuthenticationHeaders(this RestRequest restRequest)
        {
            restRequest.AddHeader("X-user", AppSettings.ProofPoint_user);
            restRequest.AddHeader("X-password", AppSettings.ProofPoint_password);
            return restRequest;
        }
    }
}
