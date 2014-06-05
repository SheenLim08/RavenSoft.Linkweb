using RavenSoft.Linkweb.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Entities.Helpers
{
    public static class CustomerAccountsExtension
    {
        public static CustomerAccount CreateCustomerAccount(
            string name, string notes)
        {
            CustomerAccount newAccount = new CustomerAccount();
            newAccount.GUID = IDGenerator.GenerateCustomerAccountID();
            newAccount.Name = name;
            newAccount.Notes = notes;

            return newAccount;
        }

        public static void UpdateCustomerAccount(this CustomerAccount customerToUpdate,
            string name, string notes)
        {
            customerToUpdate.Name = name;
            customerToUpdate.Notes = notes;
        }

        public static IQueryable<CustomerAccount> GetCustomerAccountWithMatchingName(this DbSet<CustomerAccount> customerList, string name)
        {
            return customerList.Where(currentCustomer => currentCustomer.Name.ToLower().Contains(name.ToLower())).AsQueryable();
        }

        public static CustomerAccount GetCustomerAccountWithID(this DbSet<CustomerAccount> customerList, string id)
        {
            return customerList.Single(currentCustomer => currentCustomer.GUID == id);
        }

        public static CustomerAccountAddress AddCustomerAddress(this CustomerAccount currentCustomer,
            string billingAddress, string billingAddressAccountID, string billingAddressContact, string billingAddressNotes)
        {
            CustomerAccountAddress newCustomerAddress = new CustomerAccountAddress();
            newCustomerAddress.GUID = Guid.NewGuid().ToString();
            newCustomerAddress.CustomerAccountID = currentCustomer.GUID;
            newCustomerAddress.BillingAddress = billingAddress;
            newCustomerAddress.BillingAddressAccountID = billingAddressAccountID;
            newCustomerAddress.BillingAddressContact = billingAddressContact;
            newCustomerAddress.BillingAddressNotes = billingAddressNotes;

            newCustomerAddress.CustomerAccount = currentCustomer;

            return newCustomerAddress;
        }

        public static void UpdateCustomerAddress(this CustomerAccount currentCustomer, CustomerAccountAddress addressToUpdate,
            string billingAddress, string billingAddressAccountID, string billingAddressContact, string billingAddressNotes)
        {
            addressToUpdate.CustomerAccountID = currentCustomer.GUID;
            addressToUpdate.BillingAddress = billingAddress;
            addressToUpdate.BillingAddressAccountID = billingAddressAccountID;
            addressToUpdate.BillingAddressContact = billingAddressContact;
            addressToUpdate.BillingAddressNotes = billingAddressNotes;
        }

        public static IQueryable<Transaction> GetTransactionsByBatchID(this CustomerAccount currentCustomer, string batchID)
        {
            return currentCustomer.Transactions.GetTransactionsByBatchID(batchID);
        }

        public static IQueryable<Transaction> GetTransaction(this CustomerAccount currentCustomer)
        {
            return currentCustomer.Transactions.AsQueryable();
        }

        public static IQueryable<Transaction> GetTransactionByDateRange(this CustomerAccount currentCustomer, DateTime from, DateTime to)
        {
            return currentCustomer.Transactions.GetTransactionsByDateRange(from, to);
        }
    }
}
