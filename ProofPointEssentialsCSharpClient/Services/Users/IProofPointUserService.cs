using ProofPointEssentialsCSharpClient.Models.Users;
using ProofPointEssentialsCSharpClient.Models.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Services.Users
{
    interface IProofPointUserService
    {
        /// <summary>
        /// Read a User belonging to an Organization
        /// </summary>
        /// <param name="Domain"></param>
        /// <param name="UserEmail"></param>
        UserOutputDto GetUser(string Domain, string UserEmail);

        /// <summary>
        /// Update a User belonging to an Organization
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        UserListOutputDto GetAllUsers(string Domain);

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        UserOutputDto UpdateUser(string Domain, ProofPointUserModal updateUser);

        /// <summary>
        /// Read all Users belonging to an Organization
        /// </summary>
        /// <param name="Domain"></param>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        UserOutputDto DeleteUser(string Domain, string UserEmail);

        /// <summary>
        /// Create a new User. Batch POST supported with list of User objects.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        UserListOutputDto CreateUser(string Domain, List<ProofPointUserModal> createUser);

        UserListOutputDto CreateUser(string Domain, ProofPointUserModal createUser);
    }
}