using Asi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class User : Entity
    {
        public bool IsConfirmed { get; set; }
        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }
        public UserRole Role { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; protected set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
