using Asi.Model;
using System.Threading.Tasks;

namespace Asi.Client.V2.Interfaces
{
    public interface IAuthentication
    {
        UserModel Login(UserModel user);
        Task UpdateSigniture(UserModel user);
    }
}
