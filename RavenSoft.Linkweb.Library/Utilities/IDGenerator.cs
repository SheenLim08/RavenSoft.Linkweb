using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Utilities
{
    public static class IDGenerator
    {
        public static string GenerateSystemAccountID(EnumSystemAccountType accountType)
        {
            return string.Format("{0}-{1}", accountType.ToString(), GenerateIDCode());
        }

        public static string GenerateCustomerAccountID()
        {
            return string.Format("{0}-{1}", "Cust", GenerateIDCode());
        }

        private static string GenerateIDCode()
        {
            string id = Guid.NewGuid().ToString().Split('-')[0];

            return id;
        }
    }
}
