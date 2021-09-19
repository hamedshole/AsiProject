using Asi.Model;

namespace Asi.Client.V1.Interfaces
{
    public interface IAuthentication
    {
        UserModel Login(UserModel user);
       
    }
}
