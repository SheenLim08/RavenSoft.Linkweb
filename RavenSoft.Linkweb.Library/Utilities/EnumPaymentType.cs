using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Utilities
{
    public enum EnumPaymentType
    {
        Cash,
        Check
    }

    public static class EnumPaymentTypeParser
    {
        public static EnumPaymentType ParseEnumConditionType(string paymentTypeInString)
        {
            return (EnumPaymentType)Enum.Parse(typeof(EnumPaymentType), paymentTypeInString);
        }
    }
}
