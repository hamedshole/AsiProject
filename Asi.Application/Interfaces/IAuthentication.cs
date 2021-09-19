using Asi.Model;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface IAuthentication
    {
        Task<UserModel> Login(UserModel user);
        Task ChangeUserSigniture(UserModel user);
        Task Register(UserModel user);

    }
}
