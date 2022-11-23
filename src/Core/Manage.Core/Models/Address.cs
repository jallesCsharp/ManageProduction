using Manage.Core.Enums;
using Manage.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Models
{
    [Table("Address")]
    public class Address : BaseModel
    {
        public string? Description { get; set; }
        public string? City { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public string? Number { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }
        public string? Zipcode { get; set; }
        public AddressTypeEnum AddressType { get; set; }
    }
}
