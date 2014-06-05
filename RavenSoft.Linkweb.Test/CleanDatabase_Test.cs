using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RavenSoft.Linkweb.Library.Entities;
using System.Linq;

namespace RavenSoft.Linkweb.Test
{
    [TestClass]
    public class DatabaseData_Test
    {
        [TestMethod]
        public void ClearDatabase_Test()
        {
            using (LinkwebEntities database = DatabaseInstanceTest.InitializeDatabase())
            {
                foreach (CustomerAccountAddress custAddress in database.CustomerAccountAddresses)
                    database.CustomerAccountAddresses.Remove(custAddress);

                foreach (CustomerAccount custAccount in database.CustomerAccounts)
                    database.CustomerAccounts.Remove(custAccount);

                foreach (MembershipPolicy memberPolicy in database.MembershipPolicies)
                    database.MembershipPolicies.Remove(memberPolicy);

                foreach (SystemAccount sysAccount in database.SystemAccounts)
                    database.SystemAccounts.Remove(sysAccount);

                foreach (OrganizationPolicy orgPolicy in database.OrganizationPolicies)
                    database.OrganizationPolicies.Remove(orgPolicy);

                foreach (TransactionPayment transactionPayment in database.TransactionPayments)
                    database.TransactionPayments.Remove(transactionPayment);

                foreach (Transaction transaction in database.Transactions)
                    database.Transactions.Remove(transaction);

                foreach (ServiceTypeCharge serviceTypeCharge in database.ServiceTypeCharges)
                    database.ServiceTypeCharges.Remove(serviceTypeCharge);

                foreach (ServiceType serviceType in database.ServiceTypes)
                    database.ServiceTypes.Remove(serviceType);

                foreach (Log logEntry in database.Logs)
                    database.Logs.Remove(logEntry);

                database.SaveChanges();

                Assert.AreEqual(database.CustomerAccountAddresses.Count(), 0);
                Assert.AreEqual(database.CustomerAccounts.Count(), 0);
                Assert.AreEqual(database.MembershipPolicies.Count(), 0);
                Assert.AreEqual(database.SystemAccounts.Count(), 0);
                Assert.AreEqual(database.OrganizationPolicies.Count(), 0);
                Assert.AreEqual(database.TransactionPayments.Count(), 0);
                Assert.AreEqual(database.Transactions.Count(), 0);
                Assert.AreEqual(database.ServiceTypeCharges.Count(), 0);
                Assert.AreEqual(database.ServiceTypes.Count(), 0);
                Assert.AreEqual(database.Logs.Count(), 0);
            }
        }
    }
}
