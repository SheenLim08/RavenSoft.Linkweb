using RavenSoft.Linkweb.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Entities.Helpers
{
    public static class SystemAccountsExtension
    {
        public static SystemAccount CreateSystemAccount(string name, 
            string logonName, string address, string notes, string hashedPassword, EnumSystemAccountType accountType)
        {
            SystemAccount newSystemAccount = new SystemAccount();
            newSystemAccount.GUID = IDGenerator.GenerateSystemAccountID(accountType);
            newSystemAccount.Name = name;
            newSystemAccount.LogonName = logonName;
            newSystemAccount.Address = address;
            newSystemAccount.Notes = notes;
            newSystemAccount.HashedPassword = hashedPassword;
            newSystemAccount.AccountType = accountType.ToString();

            return newSystemAccount;
        }

        public static void UpdateSystemAccount(this SystemAccount currentSystemAccount,
            string name, string logonName, string address, string notes, string hashedPassword,
            EnumSystemAccountType accountType)
        {
            currentSystemAccount.Name = name;
            currentSystemAccount.LogonName = logonName;
            currentSystemAccount.Address = address;
            currentSystemAccount.Notes = notes;
            currentSystemAccount.HashedPassword = hashedPassword;
            currentSystemAccount.AccountType = accountType.ToString();
        }

        public static IQueryable<SystemAccount> GetSystemAccountsByNameMatches(this ICollection<SystemAccount> systemAccountsList, string name)
        {
            return systemAccountsList.Where(curretnSystemAccount => curretnSystemAccount.Name.ToLower().Contains(name.ToLower())).AsQueryable();
        }

        public static SystemAccount GetSystemAccountByName(this ICollection<SystemAccount> systemAccountsList, string name)
        {
            return systemAccountsList.Single(currentSystemAccount => currentSystemAccount.Name.ToLower() == name.ToLower());
        }
    }
}
