using Manage.Core.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manage.Core.Models
{
    [Table("Users")]
    public class User : BaseModel
    {
        public User()
        {
            Address = new Address();
            Profiles = new List<Profile>();
        }

        [StringLength(100)]
        public string? UserName { get; set; }        
        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(1000)]
        public string? Password { get; set; }
        [Range(11, 14)]
        public string? Cpf { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<Profile>? Profiles { get; set; }
    }
}
