using Asi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Entities
{
    public partial class UserItems : Entity
    {

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
    }
}
