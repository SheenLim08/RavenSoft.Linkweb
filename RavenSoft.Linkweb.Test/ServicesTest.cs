using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RavenSoft.Linkweb.Library.Entities;
using RavenSoft.Linkweb.Library.Entities.Helpers;
using RavenSoft.Linkweb.Library.Utilities;
using System.Linq;

namespace RavenSoft.Linkweb.Test
{
    [TestClass]
    public class ServicesTest
    {
        LinkwebEntities linkwebDB = DatabaseInstanceTest.InitializeDatabase();

        [TestMethod]
        public void ServiceType_Test()
        {
            ServiceType newServiceType = ServiceTypesExtension.CreateNewServiceType("Cepalco Service - Region I", "Electric Service in Region I");

            ServiceTypeCharge charge1 = newServiceType.CreateNewServiceTypeCharge(0M, 5M, 0);
            ServiceTypeCharge charge2 = newServiceType.CreateNewServiceTypeCharge(500M, 6M, 1);
            ServiceTypeCharge charge3 = newServiceType.CreateNewServiceTypeCharge(1000M, 7M, 2);

            linkwebDB.ServiceTypes.Add(newServiceType); 

            linkwebDB.ServiceTypeCharges.Add(charge1);
            linkwebDB.ServiceTypeCharges.Add(charge2);
            linkwebDB.ServiceTypeCharges.Add(charge3);

            linkwebDB.SaveChanges();

            Assert.AreEqual("Cepalco Service - Region I", linkwebDB.ServiceTypes.FirstOrDefault().Name);
            Assert.AreEqual("Electric Service in Region I", linkwebDB.ServiceTypes.FirstOrDefault().Description);
           
            
            Assert.AreEqual(0M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(2).Amount);
            Assert.AreEqual(5M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(2).Charge);

            
            Assert.AreEqual(500M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(1).Amount);
            Assert.AreEqual(6M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(1).Charge);

            
            Assert.AreEqual(1000M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(0).Amount);
            Assert.AreEqual(7M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(0).Charge);
        }

        [TestMethod]
        public void ServiceTypeUpdate_Test()
        {
            ServiceType serviceType = linkwebDB.ServiceTypes.FirstOrDefault();

            serviceType.UpdateServiceType("Cepalco Service - Region II", "Electric Service in Region I", true);

            serviceType.ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(2).UpdateServiceTypeCharge(0M, 10M, 0);
            serviceType.ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(1).UpdateServiceTypeCharge(550M, 15M, 1);
            serviceType.ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(0).UpdateServiceTypeCharge(1500M, 20M, 2);

            linkwebDB.SaveChanges();

            Assert.AreEqual("Cepalco Service - Region II", linkwebDB.ServiceTypes.FirstOrDefault().Name);
            Assert.AreEqual("Electric Service in Region I", linkwebDB.ServiceTypes.FirstOrDefault().Description);

            
            Assert.AreEqual(0M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(2).Amount);
            Assert.AreEqual(10M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(2).Charge);

            
            Assert.AreEqual(550M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(1).Amount);
            Assert.AreEqual(15M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(1).Charge);

            
            Assert.AreEqual(1500M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(0).Amount);
            Assert.AreEqual(20M,
                linkwebDB.ServiceTypes.FirstOrDefault().ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(0).Charge);
        }

        [TestMethod]
        public void ServiceType_RemoveServiceTypeCharge_Test()
        {
            ServiceType serviceType = linkwebDB.ServiceTypes.FirstOrDefault();
            ServiceTypeCharge chargeEntryToRemove = serviceType.ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(2);

            serviceType.ServiceTypeCharges.Remove(
                chargeEntryToRemove);

            linkwebDB.SaveChanges();

            Assert.AreEqual(2, serviceType.ServiceTypeCharges.Count());
            Assert.AreEqual(1500M, serviceType.ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(1).Amount);
            Assert.AreEqual(550M, serviceType.ServiceTypeCharges.OrderByDescending(currentServiceType => currentServiceType.IndexLocation).ElementAt(0).Amount);
        }

        [TestMethod]
        public void ServiceType_GetServiceTypeCharge_Test()
        {
            ServiceType serviceType = linkwebDB.ServiceTypes.FirstOrDefault();

            Assert.AreEqual(20M, serviceType.GetServiceTypeChargeFromAmount(1800M));
            Assert.AreEqual(15M, serviceType.GetServiceTypeChargeFromAmount(550M));
        }
    }
}
