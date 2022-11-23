using Manage.Core.Interfaces.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Core.Configs
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string? Server { get; set; } = String.Empty;
        public string? InitialCatalog { get; set; } = String.Empty;
        public string? UserID { get; set; } = String.Empty;
        public string? Password { get; set; } = String.Empty;
        public string? TipoString { get; set; } = String.Empty;
        public string? Uf { get; set; } = String.Empty;
        public string? StateMode { get; set; } = String.Empty;
    }
}
