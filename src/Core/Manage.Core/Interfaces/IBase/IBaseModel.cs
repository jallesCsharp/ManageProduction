using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Interfaces.IBase
{
    public interface IBaseModel
    {
        Guid Id { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        bool Active { get; set; }
    }
}
