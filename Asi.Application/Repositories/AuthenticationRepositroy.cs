
using Asi.Application.Util;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Threading.Tasks;
using IAuthentication = Asi.Application.Interface.IAuthentication;


namespace Asi.Application.Repositories
{
    internal class AuthenticationRepositroy : IAuthentication
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public AuthenticationRepositroy(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }



        public async Task<UserModel> Login(UserModel user)
        {
            User userdto = await _dbBusinessUnit.Authentication.Login(user.Username, user.Password);
            UserModel userModel = _mapper.Map<UserModel>(userdto);
            return userModel;
        }
        public async Task ChangeUserSigniture(UserModel user)
        {
            string imagepath = StaticMethods.SaveImage(user.Signiture, StaticMethods.SavedImageFormat.PNG, StaticMethods.ImageDirectory.Signitures);
            await _dbBusinessUnit.Authentication.ChangeUserSigniture(user.PersonId, imagepath);
        }
        public async Task Register(UserModel user)
        {
            User userentity = new User
            {
                Username = user.Username,
                Password = user.Password,
                PersonId = user.PersonId,
                RoleId = user.RoleId

            };
            await _dbBusinessUnit.Users.CreateAsync(userentity);
        }
    }
}
