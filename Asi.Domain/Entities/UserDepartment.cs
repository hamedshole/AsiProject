using Asi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class UserDepartment : Entity
    {


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public User User { get; set; }
        public Department Department { get; set; }
    }
}
