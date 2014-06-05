using RavenSoft.Linkweb.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Entities.Helpers
{
    public static class TransactionsExtension
    {
        public static Transaction CreateTransaction(string transactioinID, CustomerAccount customer, CustomerAccountAddress customerAddress, string billingID,
            EnumTransactionType transactionType, decimal policyWaybillCharge, ServiceType serviceType, decimal serviceTypeCharge, 
            decimal vatCharge, string batchTransactionID)
        {
            Transaction newTransaction = new Transaction();
            newTransaction.TransactionID = transactioinID;
            newTransaction.CustomerGUID = customer.GUID;
            newTransaction.CustomerAccountAddressGUID = customerAddress.GUID;
            newTransaction.BillingAccountID = billingID;
            newTransaction.TransactionType = transactionType.ToString();
            newTransaction.PolicyWayBillCharge = policyWaybillCharge;
            newTransaction.ServiceTypeGUID = serviceType.GUID;
            newTransaction.ServiceTypeCharge = serviceTypeCharge;
            newTransaction.TimeStamp = DateTime.Now;
            newTransaction.VATCharge = vatCharge;
            newTransaction.BatchTransactionID = batchTransactionID;

            newTransaction.CustomerAccount = customer;
            newTransaction.CustomerAccountAddress = customerAddress;
            newTransaction.ServiceType = serviceType;

            return newTransaction;
        }

        public static IQueryable<Transaction> GetTransactionsByCustomer(this ICollection<Transaction> transactionList,
            string customerGUID)
        {
            return transactionList.Where(currentCustomer => currentCustomer.CustomerGUID == customerGUID).AsQueryable();
        }

        public static IQueryable<Transaction> GetTransactionsByBatchID(this ICollection<Transaction> transactionList,
            string batchID)
        {
            return transactionList.Where(currentCustomer => currentCustomer.BatchTransactionID == batchID).AsQueryable();
        }

        public static TransactionPayment AddTransactionPayment(this Transaction currentTransaction, 
            EnumPaymentType paymentType, decimal amount, DateTime timeStamp, DateTime datePaid, string notes)
        {
            TransactionPayment newTransactionPayment = new TransactionPayment();
            newTransactionPayment.GUID = Guid.NewGuid().ToString();
            newTransactionPayment.TransactionID = currentTransaction.TransactionID;
            newTransactionPayment.PaymentType = paymentType.ToString();
            newTransactionPayment.Amount = amount;
            newTransactionPayment.TimeStamp = timeStamp;
            newTransactionPayment.DatePaid = datePaid;
            newTransactionPayment.Notes = notes;

            newTransactionPayment.Transaction = currentTransaction;

            return newTransactionPayment;
        }

        public static void RemoveTransactionPayment(this ICollection<Transaction> transactionList, Transaction transactionToRemove)
        {
            transactionList.Remove(transactionToRemove);
        }

        public static Transaction GetTransactionByTransactionID(this ICollection<Transaction> transactionList, string transactionID)
        {
            return transactionList.Single(currentTransaction => 
                currentTransaction.TransactionID.ToLower() == transactionID.ToLower());
        }

        public static IQueryable<Transaction> GetTransactionsByDateRange(this ICollection<Transaction> transactionList,
            DateTime from, DateTime to)
        {
            return transactionList.Where(currentTransaction =>
                currentTransaction.TimeStamp >= from &&
                currentTransaction.TimeStamp <= to).AsQueryable();
        }
    }
}
