using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Models.Users
{
    public class UpdateUserError
    {
        public int status { get; internal set; }
        public string error_message { get; internal set; }
        public string identifier { get; internal set; }
    }
}
