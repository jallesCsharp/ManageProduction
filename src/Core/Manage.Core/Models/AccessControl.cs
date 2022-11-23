using Manage.Core.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manage.Core.Models
{
    [Table("AccessControls")]
    public class AccessControl : BaseModel
    {
        public AccessControl()
        {
            Profiles = new Profile();
        }

        [StringLength(100)]
        public string? DescriptionAccess { get; set; }
        public bool Visualize { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Alter { get; set; }
        public bool Save { get; set; }

        public virtual Profile Profiles { get; set; }
    }
}
