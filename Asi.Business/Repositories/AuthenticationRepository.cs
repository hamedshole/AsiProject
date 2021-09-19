using Asi.Domain.Entities;
using Asi.Domain.Exceptions;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class AuthenticationRepository : IAuthentication
    {
        private readonly IAsiDbContext _dbContext;

        public AuthenticationRepository(IAsiDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task Register(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(); ;

        }


        async Task<User> IAuthentication.Login(string username, string password)
        {
            var user = await _dbContext.Users.Where(x => x.Username == username).Include(x => x.Person).FirstOrDefaultAsync(); ;
            ExceptionMethods.UserExistCheck(user);
            bool passwordMatch = this.CheckPassword(user, password);
            ExceptionMethods.CheckPassword(passwordMatch);
            return user;
        }
        private bool CheckPassword(User user, string password)
        {
            return user.Password == password;
        }

        public async Task ChangeUserSigniture(int personId, string imagePath)
        {
            Person person = await _dbContext.Persons.FindAsync(personId);
            person.Signiture = imagePath;
            _dbContext.Persons.Update(person);
            await _dbContext.SaveChangesAsync();
        }

    }
}
