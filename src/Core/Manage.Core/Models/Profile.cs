using Manage.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manage.Core.Models
{
    [Table("Profiles")]
    public class Profile : BaseModel
    {
        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        [ForeignKey("AccessControl")]
        public Guid? AccessControlId { get; set; }

        public virtual AccessControl? AccessControls { get; set; }
        public virtual User? Users { get; set; }
    }
}
