using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Interfaces.Configurations
{
    public interface IConnectionStrings
    {
        public string? Server { get; set; }
        public string? InitialCatalog { get; set; }
        public string? UserID { get; set; }
        public string? Password { get; set; }
        public string? TipoString { get; set; }
        public string? Uf { get; set; }
        public string? StateMode { get; set; }
    }
}
