using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RavenSoft.Linkweb.Library.Concreate;
using Moq;
using System.Collections.Generic;
using System.Linq;
using RavenSoft.Linkweb.Library.Entities.Helpers;
using RavenSoft.Linkweb.Library.Entities;
using RavenSoft.Linkweb.Library.Utilities;

namespace RavenSoft.Linkweb.Test
{
    [TestClass]
    public class Accounts_UnitTest
    {
        LinkwebEntities linkWebDB = DatabaseInstanceTest.InitializeDatabase();

        [TestMethod]
        public void SystemAccount_Test()
        {
            SystemAccount sysAccount1 = SystemAccountsExtension.CreateSystemAccount("Sheen Ismhael Lim",
                "sheenismhael.lim", "B3 L1-2 Amparo Village, Tambaling", "Test account 1", PasswordHasher.HashPassword("gastovski"), EnumSystemAccountType.AdminAccount);

            linkWebDB.SystemAccounts.Add(sysAccount1);
            linkWebDB.SaveChanges();

            Assert.AreEqual(linkWebDB.SystemAccounts.FirstOrDefault().GUID,
                sysAccount1.GUID);
        }

        [TestMethod]
        public void SystemAccountUpdate_Test()
        {
            SystemAccount sysAccount1 = linkWebDB.SystemAccounts.FirstOrDefault();

            sysAccount1.UpdateSystemAccount("Gian Ismhael Lim", "gianismhael.lim", "B3 L1-2 Amparo Village, Tambaling", "Test account 1", PasswordHasher.HashPassword("gastovski"), EnumSystemAccountType.TellerAcount);
            linkWebDB.SaveChanges();

            Assert.AreEqual(linkWebDB.SystemAccounts.FirstOrDefault().Name, "Gian Ismhael Lim");
        }

        [TestMethod]
        public void CustomerAccount_Test()
        {
            CustomerAccount custAccount1 = CustomerAccountsExtension.CreateCustomerAccount("Jose Guingao III", "wla lang");

            CustomerAccountAddress address1 = custAccount1.AddCustomerAddress("Camaman-an", "Jose Guingao III", "0915548857", "wala lang");
            CustomerAccountAddress address2 = custAccount1.AddCustomerAddress("Camaman-an2", "Jose Guingao III2", "09155488572", "wala lang2");
            
            linkWebDB.CustomerAccounts.Add(custAccount1);
            linkWebDB.CustomerAccountAddresses.Add(address1);
            linkWebDB.CustomerAccountAddresses.Add(address2);

            linkWebDB.SaveChanges();
            
            Assert.AreEqual(custAccount1.GUID, linkWebDB.CustomerAccounts.FirstOrDefault().GUID);
            Assert.AreEqual(address2.GUID, linkWebDB.CustomerAccounts.FirstOrDefault().CustomerAccountAddresses.ElementAt(1).GUID);
            Assert.AreEqual(address1.GUID, linkWebDB.CustomerAccounts.FirstOrDefault().CustomerAccountAddresses.ElementAt(0).GUID);
        }

        [TestMethod]
        public void CustomerAccountUpdate_Test()
        {
            CustomerAccount custAccount1 = linkWebDB.CustomerAccounts.FirstOrDefault();

            CustomerAccountAddress address1 = custAccount1.CustomerAccountAddresses.ElementAt(1);
            CustomerAccountAddress address2 = custAccount1.CustomerAccountAddresses.ElementAt(0);

            custAccount1.UpdateCustomerAccount("Rose Lorenze Pepito", "wla lang");
            custAccount1.UpdateCustomerAddress(address1, "Bogu - ambot lang unsai full addresss", "Jose Guingao III", "0915548857", "wala lang");
            custAccount1.UpdateCustomerAddress(address2, "Bogu2 - ambot lang unsai full addresss", "Jose Guingao III", "0915548857", "wala lang");

            linkWebDB.SaveChanges();

            Assert.AreEqual(linkWebDB.CustomerAccounts.FirstOrDefault().Name, "Rose Lorenze Pepito");
            Assert.AreEqual(linkWebDB.CustomerAccounts.FirstOrDefault().CustomerAccountAddresses.ElementAt(1).BillingAddress, "Bogu - ambot lang unsai full addresss");
            Assert.AreEqual(linkWebDB.CustomerAccounts.FirstOrDefault().CustomerAccountAddresses.ElementAt(0).BillingAddress, "Bogu2 - ambot lang unsai full addresss");
        }
    }
}
