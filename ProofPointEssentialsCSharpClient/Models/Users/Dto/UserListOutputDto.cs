using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Models.Users.Dto
{
    public class UserListOutputDto
    {
        public bool IsSuccessful { get; internal set; }
        
        public List<ProofPointUserModal> users { get; set; }

        public List<UpdateUserError> errors { get; internal set; }
    }
}