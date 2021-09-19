using Asi.Domain.Common;

namespace Asi.Domain.Entities
{
    public partial class UserRole : Entity
    {
        public string Title { get; set; }
        public string Permissions { get; set; }
    }
}