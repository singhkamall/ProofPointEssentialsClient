using ProofPointEssentialsCSharpClient.Models.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ProofPointEssentialsCSharpClient.Models.Users
{
    public class ProofPointUserModal : ProofPointUserBase
    {
        public ProofPointUserModal()
        {

        }

        public ProofPointUserModal(UserOutputDto userOutputDto)
        {
            Mapper.Map(userOutputDto, this, typeof(UserOutputDto), typeof(ProofPointUserModal));
        }
    }
}