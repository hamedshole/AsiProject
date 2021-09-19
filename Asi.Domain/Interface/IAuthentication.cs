using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IAuthentication
    {
        Task<User> Login(string username, string password);
        Task Register(User user);
        Task ChangeUserSigniture(int personId, string imagePath);
    }
}
