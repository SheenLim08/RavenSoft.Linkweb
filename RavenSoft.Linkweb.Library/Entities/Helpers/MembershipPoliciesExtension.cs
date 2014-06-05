using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Entities.Helpers
{
    public static class MembershipPoliciesExtension
    {
        public static MembershipPolicy CreateNewMembershipPolicy(string name, string description,
            decimal monthlyFee, decimal membershipFee, decimal waybillCharge,
            int maxPickupWayBillPerMonth, int maxDeliveryWayBillPerMonth, int maxBillEntries,
            decimal insurance, int membershipMaturityInMonths, decimal penaltyCharge)
        {
            MembershipPolicy newMembershipPolicy = new MembershipPolicy();
            newMembershipPolicy.GUID = Guid.NewGuid().ToString();
            newMembershipPolicy.Name = name;
            newMembershipPolicy.Description = description;
            newMembershipPolicy.MonthlyFee = monthlyFee;
            newMembershipPolicy.MembershipFee = membershipFee;
            newMembershipPolicy.WayBillCharge = waybillCharge;
            newMembershipPolicy.MaxPickupWayBillPerMonth = maxPickupWayBillPerMonth;
            newMembershipPolicy.MaxDeliveryWayBillPerMonth = maxDeliveryWayBillPerMonth;
            newMembershipPolicy.MaxBillEntries = maxBillEntries;
            newMembershipPolicy.Insurance = insurance;
            newMembershipPolicy.MembershipMaturityInMonths = membershipMaturityInMonths;
            newMembershipPolicy.PenaltyCharge = penaltyCharge;

            return newMembershipPolicy;
        }

        public static void UpdateMembershipPolicy(this MembershipPolicy policyToUpdate,
            string name, string description,
            decimal monthlyFee, decimal membershipFee, decimal waybillCharge,
            int maxPickupWayBillPerMonth, int maxDeliveryWayBillPerMonth, int maxBillEntries,
            decimal insurance, int membershipMaturityInMonths, decimal penaltyCharge)
        {
            policyToUpdate.Name = name;
            policyToUpdate.Description = description;
            policyToUpdate.MonthlyFee = monthlyFee;
            policyToUpdate.MembershipFee = membershipFee;
            policyToUpdate.WayBillCharge = waybillCharge;
            policyToUpdate.MaxPickupWayBillPerMonth = maxPickupWayBillPerMonth;
            policyToUpdate.MaxDeliveryWayBillPerMonth = maxDeliveryWayBillPerMonth;
            policyToUpdate.MaxBillEntries = maxBillEntries;
            policyToUpdate.Insurance = insurance;
            policyToUpdate.MembershipMaturityInMonths = membershipMaturityInMonths;
            policyToUpdate.PenaltyCharge = penaltyCharge;
        }

        public static MembershipPolicy GetMembershipPolicyByName(this DbSet<MembershipPolicy> membershipPolicyList, string name)
        {
            return membershipPolicyList.Single(currentMemberhsipPolicy => currentMemberhsipPolicy.Name.ToLower() == name.ToLower());
        }

        public static IQueryable<MembershipPolicy> GetMembershipPolicyByNameMatches(this DbSet<MembershipPolicy> membershipPolicyList, string name)
        {
            return membershipPolicyList.Where(currentMemberhsipPolicy => currentMemberhsipPolicy.Name.Contains(name.ToLower()));
        }
    }
}
