using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Utilities
{
    public enum EnumTransactionType
    {
        Pickup,
        Delivery,
        Walkin
    }

    public static class EnumTransactionTypeParser
    {
        public static EnumTransactionType ParseEnumConditionType(string transactionTypeInString)
        {
            return (EnumTransactionType)Enum.Parse(typeof(EnumTransactionType), transactionTypeInString);
        }
    }
}
