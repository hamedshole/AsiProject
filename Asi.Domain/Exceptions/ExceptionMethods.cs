using Asi.Domain.Entities;
using System;

namespace Asi.Domain.Exceptions
{
    public static class ExceptionMethods
    {
        public static void UserExistCheck(User user)
        {
            if (user == null)
                throw new Exception("چنین کاربری وجود ندارد");
        }
        public static void CheckPassword(bool isPasswordCorrect)
        {
            if (!isPasswordCorrect)
                throw new Exception("رمزعبور اشتباه است");
        }
    }
}
