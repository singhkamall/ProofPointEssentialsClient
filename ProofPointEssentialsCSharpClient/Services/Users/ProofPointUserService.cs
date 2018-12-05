using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProofPointEssentialsCSharpClient.Consts;
using ProofPointEssentialsCSharpClient.Models.Users;
using ProofPointEssentialsCSharpClient.Models.Users.Dto;
using ProofPointEssentialsCSharpClient.Utility;
using RestSharp;

namespace ProofPointEssentialsCSharpClient.Services.Users
{
    public class ProofPointUserService : IProofPointUserService
    {
        private RestClient _client;
        private readonly log4net.ILog _log;

        public ProofPointUserService()
        {
            _log = LoggerService.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(x =>
            {
                x.CreateMap<UserOutputDto, ProofPointUserModal>().ReverseMap();
            });
        }

        public UserOutputDto GetUser(string Domain, string UserEmail)
        {
            UserOutputDto output = new UserOutputDto { IsSuccessful = false };
            string resource = ProofPointEndpoints.GetUserEndpoint(Domain, UserEmail);

            try
            {
                _log.Info($"INITIATING GetUser: {resource}");

                if (Domain.IsNullOrEmpty())
                    throw new Exception("Domain was not provided");

                if (UserEmail.IsNullOrEmpty())
                    throw new Exception("UserEmail was not provided");

                var request = new RestRequest(resource, Method.GET).AddAuthenticationHeaders();

                var response = _client.Execute<UserOutputDto>(request);

                if (response.Data == null)
                    response.Data = new UserOutputDto();
                response.Data.IsSuccessful = response.IsSuccessful;

                _log.Info($"RESPONSE GetUser: {response.IsSuccessful}");
                if (!response.IsSuccessful)
                    _log.Error($"ERROR GetUser: {JsonConvert.SerializeObject(response.Data?.errors)}");

                output = response.Data;
            }
            catch (Exception ex)
            {
                _log.Fatal("EXCEPTION GetUser", ex);
            }
            finally
            {
                _log.Info($"ENDED GetUser: {resource}");
            }

            return output;
        }

        public UserListOutputDto GetAllUsers(string Domain)
        {
            UserListOutputDto output = new UserListOutputDto { IsSuccessful = false };
            string resource = ProofPointEndpoints.GetUsersEndpoint(Domain);

            try
            {
                _log.Info($"INITIATING GetAllUsers: {resource}");

                if (Domain.IsNullOrEmpty())
                    throw new Exception("Domain was not provided");

                var request = new RestRequest(resource, Method.GET).AddAuthenticationHeaders();

                IRestResponse<UserListOutputDto> response = _client.Execute<UserListOutputDto>(request);
                response.Data.IsSuccessful = response.IsSuccessful;

                _log.Info($"RESPONSE GetAllUsers: {response.IsSuccessful}");
                if (response.Data.errors != null && response.Data.errors.Any())
                    _log.Error($"ERROR GetAllUsers: {JsonConvert.SerializeObject(response.Data?.errors)}");

                output = response.Data;
            }
            catch (Exception ex)
            {
                _log.Fatal("EXCEPTION GetAllUsers: ", ex);
            }
            finally
            {
                _log.Info($"ENDED GetAllUsers: {resource}");
            }

            return output;
        }

        public UserListOutputDto CreateUser(string Domain, List<ProofPointUserModal> createUser)
        {
            UserListOutputDto output = new UserListOutputDto { IsSuccessful = false };
            string resource = ProofPointEndpoints.CreateUserEndpoint(Domain);

            try
            {
                _log.Info($"INITIATING CreateUser: {resource} | {string.Join(",", createUser.Select(x => x.primary_email))}");

                if (Domain.IsNullOrEmpty())
                    throw new Exception("Domain was not provided");

                if (createUser.Any(x => x.primary_email.IsNullOrEmpty()))
                    throw new Exception("UserEmail was not provided");

                var request = new RestRequest(resource, Method.POST).AddAuthenticationHeaders();
                request.AddJsonBody(createUser);

                IRestResponse<UserListOutputDto> response = _client.Execute<UserListOutputDto>(request);
                response.Data.IsSuccessful = response.IsSuccessful;

                _log.Info($"RESPONSE CreateUser: {response.IsSuccessful}");
                if (response.Data.errors != null && response.Data.errors.Any())
                    _log.Error($"ERROR CreateUser: {JsonConvert.SerializeObject(response.Data?.errors)}");

                output = response.Data;
            }
            catch (Exception ex)
            {
                _log.Fatal("EXCEPTION CreateUser: ", ex);
            }
            finally
            {
                _log.Info($"ENDED CreateUser: {resource}");
            }

            return output;
        }

        public UserListOutputDto CreateUser(string Domain, ProofPointUserModal createUser)
        {
            UserListOutputDto output = new UserListOutputDto { IsSuccessful = false };
            string resource = ProofPointEndpoints.CreateUserEndpoint(Domain);

            try
            {
                _log.Info($"INITIATING CreateUser: {resource} | {createUser.primary_email}");

                if (Domain.IsNullOrEmpty())
                    throw new Exception("Domain was not provided");

                if (createUser.primary_email.IsNullOrEmpty())
                    throw new Exception("UserEmail was not provided");

                var request = new RestRequest(resource, Method.POST).AddAuthenticationHeaders();
                request.AddJsonBody(createUser);

                IRestResponse<UserListOutputDto> response = _client.Execute<UserListOutputDto>(request);
                response.Data.IsSuccessful = response.IsSuccessful;

                _log.Info($"RESPONSE CreateUser: {response.IsSuccessful}");
                if (response.Data.errors != null && response.Data.errors.Any())
                    _log.Error($"ERROR CreateUser: {JsonConvert.SerializeObject(response.Data?.errors)}");

                output = response.Data;
            }
            catch (Exception ex)
            {
                _log.Fatal("EXCEPTION CreateUser: ", ex);
            }
            finally
            {
                _log.Info($"ENDED CreateUser: {resource}");
            }

            return output;
        }

        public UserOutputDto UpdateUser(string Domain, ProofPointUserModal updateUser)
        {
            UserOutputDto output = new UserOutputDto { IsSuccessful = false };
            string resource = ProofPointEndpoints.UpdateUserEndpoint(Domain, updateUser.primary_email);

            try
            {
                _log.Info($"INITIATING UpdateUser: {resource} | {updateUser.primary_email}");

                if (Domain.IsNullOrEmpty())
                    throw new Exception("Domain was not provided");

                if (updateUser.primary_email.IsNullOrEmpty())
                    throw new Exception("UserEmail was not provided");

                var request = new RestRequest(resource, Method.PUT).AddAuthenticationHeaders();
                request.AddJsonBody(updateUser);

                IRestResponse<UserOutputDto> response = _client.Execute<UserOutputDto>(request);
                if (response.Data == null)
                    response.Data = new UserOutputDto();
                response.Data.IsSuccessful = response.IsSuccessful;

                _log.Info($"RESPONSE UpdateUser: {response.IsSuccessful}");
                if (!response.IsSuccessful)
                    _log.Error($"ERROR UpdateUser: {JsonConvert.SerializeObject(response.Data?.errors)}");

                output = response.Data;
            }
            catch (Exception ex)
            {
                _log.Fatal("EXCEPTION UpdateUser: ", ex);
            }
            finally
            {
                _log.Info($"ENDED UpdateUser: {resource}");
            }

            return output;
        }

        public UserOutputDto DeleteUser(string Domain, string UserEmail)
        {
            UserOutputDto output = new UserOutputDto { IsSuccessful = false };
            string resource = ProofPointEndpoints.DeleteUserEndpoint(Domain, UserEmail);

            try
            {
                _log.Info($"INITIATING DeleteUser: {resource}");

                if (Domain.IsNullOrEmpty())
                    throw new Exception("Domain was not provided");

                if (UserEmail.IsNullOrEmpty())
                    throw new Exception("UserEmail was not provided");

                var request = new RestRequest(resource, Method.DELETE).AddAuthenticationHeaders();

                var response = _client.Execute<UserOutputDto>(request);
                if (response.Data == null)
                    response.Data = new UserOutputDto();
                response.Data.IsSuccessful = response.IsSuccessful;

                _log.Info($"RESPONSE DeleteUser: {response.IsSuccessful}");
                if (!response.IsSuccessful)
                    _log.Error($"ERROR DeleteUser: {JsonConvert.SerializeObject(response.Data?.errors)}");

                output = response.Data;
            }
            catch (Exception ex)
            {
                _log.Fatal("EXCEPTION DeleteUser: ", ex);
            }
            finally
            {
                _log.Info($"ENDED DeleteUser: {resource}");
            }

            return output;
        }
    }
}