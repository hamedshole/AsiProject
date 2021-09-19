using Asi.Client.Util.Interfaces;
using Asi.Model;
using System.Threading.Tasks;
using IV1Authentication = Asi.Client.V1.Interfaces.IAuthentication;
using IV2Authentication = Asi.Client.V2.Interfaces.IAuthentication;


namespace Asi.Client.Repositories
{
    internal class AuthenticationRepositroy : IV1Authentication, IV2Authentication
    {
        private readonly ICustomHttpClient _httpClient;
        private readonly string _route;
        private readonly int _version;

        public AuthenticationRepositroy(ICustomHttpClient httpClient, string route,int version=1)
        {
            this._version = version;
            _httpClient = httpClient;
            _route = route;
        }



        public UserModel Login(UserModel user)
        {
            _httpClient.SetRoute(_route);
            return Task.Run(async () => await _httpClient.Post<UserModel, UserModel>(user,version:_version)).Result;
        }
        public Task UpdateSigniture(UserModel user)
        {
            _httpClient.SetRoute(_route);
            return Task.Run(async () => await _httpClient.Post(user, uri: "updateusersigniture", version: _version));
        }
    }
}
