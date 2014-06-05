using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Utilities
{
    public enum EnumSystemAccountType
    {
        AdminAccount, TellerAcount
    }

    public static class EnumSystemAccountTypeParser
    {
        public static EnumSystemAccountType ParseEnumSystemAccountType(string accountTypeInString)
        {
            return (EnumSystemAccountType)Enum.Parse(typeof(EnumSystemAccountType), accountTypeInString);
        }
    }
}
