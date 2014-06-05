using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RavenSoft.Linkweb.Library.Entities;
using RavenSoft.Linkweb.Library.Entities.Helpers;

namespace RavenSoft.Linkweb.Test
{
    [TestClass]
    public class Policies_UnitTest
    {
        LinkwebEntities linkWebDB = DatabaseInstanceTest.InitializeDatabase();

        [TestMethod]
        public void MembershipPolicy_Test()
        {
            MembershipPolicy newMembershipPolicy = MembershipPoliciesExtension.CreateNewMembershipPolicy(
                "Default Membership Policy", "Testing", 5M, 150M, 25M, 1, 0, 3, 10000M, 12, 50M);
            linkWebDB.MembershipPolicies.Add(newMembershipPolicy);
            linkWebDB.SaveChanges();

            Assert.AreEqual(newMembershipPolicy.GUID, linkWebDB.MembershipPolicies.FirstOrDefault().GUID);
        }

        [TestMethod]
        public void MembershipPolicyUpdate_Test()
        {
            MembershipPolicy membershipPolicy = linkWebDB.MembershipPolicies.FirstOrDefault();

            membershipPolicy.UpdateMembershipPolicy(
                "First Default Membership Policy", "Testing2", 5M, 150M, 25M, 1, 0, 3, 10000M, 12, 50M);

            Assert.AreEqual("First Default Membership Policy", linkWebDB.MembershipPolicies.FirstOrDefault().Name);
            Assert.AreEqual("Testing2", linkWebDB.MembershipPolicies.FirstOrDefault().Description);
        }
    }
}
