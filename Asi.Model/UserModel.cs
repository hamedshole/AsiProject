using System.Collections.Generic;

namespace Asi.Model
{
    public class UserModel : BaseModel
    {
      
        public int RoleId { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string Signiture { get; set; }
        public List<int> UserItems { get; set; }
        public List<int> UserDepartments { get; set; }
    }
}
