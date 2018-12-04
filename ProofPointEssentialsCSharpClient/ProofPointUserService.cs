using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProofPointEssentialsCSharpClient.Consts;
using ProofPointEssentialsCSharpClient.Models.Users;
using ProofPointEssentialsCSharpClient.Models.Users.Dto;
using ProofPointEssentialsCSharpClient.Utility;
using RestSharp;

namespace ProofPointEssentialsCSharpClient
{
    public class ProofPointUserService : IProofPointUserService
    {
        RestClient _client;
        public ProofPointUserService()
        {
            if (AppSettings.ProofPoint_BaseUrl.IsNullOrEmpty())
                throw new Exception("Base Uri was not found in configuration. Please make sure \"ProofPointEssentials:Base\" is defined in your configuration file.");

            if (AppSettings.ProofPoint_user.IsNullOrEmpty())
                throw new Exception("User email was not found in configuration. Please make sure \"ProofPointEssentials:Username\" is defined in your configuration file.");

            if (AppSettings.ProofPoint_password.IsNullOrEmpty())
                throw new Exception("User password was not found in configuration. Please make sure \"ProofPointEssentials:Password\" is defined in your configuration file.");

            InitAutoMap();

            _client = new RestClient(AppSettings.ProofPoint_BaseUrl);
        }

        private void InitAutoMap()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
                x.CreateMap<UserOutputDto, ProofPointUserModal>().ReverseMap();
            });
        }

        public UserOutputDto GetUser(string Domain, string UserEmail)
        {
            if (Domain.IsNullOrEmpty())
                throw new Exception("Domain was not provided");

            if (UserEmail.IsNullOrEmpty())
                throw new Exception("UserEmail was not provided");

            var request = new RestRequest(ProofPointEndpoints.GetUserEndpoint(Domain, UserEmail), Method.GET);

            // add HTTP Headers
            request.AddHeader("X-user", AppSettings.ProofPoint_user);
            request.AddHeader("X-password", AppSettings.ProofPoint_password);

            var result = _client.Execute<UserOutputDto>(request);

            if (result.Data == null)
                result.Data = new UserOutputDto();
            result.Data.IsSuccessful = result.IsSuccessful;


            return result.Data;
        }

        public UserListOutputDto GetAllUsers(string Domain)
        {
            if (Domain.IsNullOrEmpty())
                throw new Exception("Domain was not provided");

            var request = new RestRequest(ProofPointEndpoints.GetUsersEndpoint(Domain), Method.GET);

            // add HTTP Headers
            request.AddHeader("X-user", AppSettings.ProofPoint_user);
            request.AddHeader("X-password", AppSettings.ProofPoint_password);

            IRestResponse<UserListOutputDto> response = _client.Execute<UserListOutputDto>(request);
            response.Data.IsSuccessful = response.IsSuccessful;

            return response.Data;
        }

        public UserListOutputDto CreateUser(string Domain, List<ProofPointUserModal> createUser)
        {
            if (Domain.IsNullOrEmpty())
                throw new Exception("Domain was not provided");

            if (createUser.Any(x => x.primary_email.IsNullOrEmpty()))
                throw new Exception("UserEmail was not provided");

            var request = new RestRequest(ProofPointEndpoints.CreateUserEndpoint(Domain), Method.POST);

            // add HTTP Headers
            request.AddHeader("X-user", AppSettings.ProofPoint_user);
            request.AddHeader("X-password", AppSettings.ProofPoint_password);

            request.AddJsonBody(createUser);

            UserListOutputDto result = null;

            //// async with deserialization
            //var asyncHandle = _client.Execute<List<ProofPointUserModal>>(request, response =>
            //{
            //    getUserDto = response.Data;
            //});

            // TODO: Error handling
            // 1. Could be partially succeed
            // 2. Handle errors and success results
            // 3. Log results

            IRestResponse<UserListOutputDto> response = _client.Execute<UserListOutputDto>(request);
            result = response.Data;

            return result;
        }

        public UserOutputDto UpdateUser(string Domain, ProofPointUserModal updateUser)
        {
            if (Domain.IsNullOrEmpty())
                throw new Exception("Domain was not provided");

            if (updateUser.primary_email.IsNullOrEmpty())
                throw new Exception("UserEmail was not provided");

            var request = new RestRequest(ProofPointEndpoints.UpdateUserEndpoint(Domain, updateUser.primary_email), Method.PUT);

            // add HTTP Headers
            request.AddHeader("X-user", AppSettings.ProofPoint_user);
            request.AddHeader("X-password", AppSettings.ProofPoint_password);

            request.AddJsonBody(updateUser);

            IRestResponse<UserOutputDto> response = _client.Execute<UserOutputDto>(request);
            if (response.Data == null)
                response.Data = new UserOutputDto();
            response.Data.IsSuccessful = response.IsSuccessful;

            return response.Data;
        }

        public UserOutputDto DeleteUser(string Domain, string UserEmail)
        {
            if (Domain.IsNullOrEmpty())
                throw new Exception("Domain was not provided");

            if (UserEmail.IsNullOrEmpty())
                throw new Exception("UserEmail was not provided");

            var request = new RestRequest(ProofPointEndpoints.DeleteUserEndpoint(Domain, UserEmail), Method.DELETE);

            // add HTTP Headers
            request.AddHeader("X-user", AppSettings.ProofPoint_user);
            request.AddHeader("X-password", AppSettings.ProofPoint_password);

            var result = _client.Execute<UserOutputDto>(request);

            if (result.Data == null)
                result.Data = new UserOutputDto();
            result.Data.IsSuccessful = result.IsSuccessful;

            return result.Data;
        }
    }
}