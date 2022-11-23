using System.ComponentModel;

namespace Manage.Core.Enums
{
    public enum AddressTypeEnum
    {
        [Description("Indefinido")]
        NotDefined = 0,
        [Description("Casa")]
        Home = 1,
        [Description("Trabalho")]
        Work = 2,
        [Description("Outro")]
        Other = 3
    }
}
