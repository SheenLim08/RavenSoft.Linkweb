using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Entities.Helpers
{
    public static class PolicySubscriptionsExtension
    {
        public static bool IsMemberhipPolicyAppliedOnAddress(this CustomerAccountAddress currentAddress)
        {
            return currentAddress.PolicySubscriptions.FirstOrDefault() != null;
        }

        public static bool IsCustomerAddressMembershipPolicyExpired(this CustomerAccountAddress currentAddress)
        {
            if (currentAddress.PolicySubscriptions.FirstOrDefault() != null && currentAddress.PolicySubscriptions.Count() >= 1)
            {
                PolicySubscription currentSubsriptionPolicy = currentAddress.PolicySubscriptions.FirstOrDefault();

                return DateTime.Now.Date <= currentSubsriptionPolicy.NextRenewalDate.Date;
            }

            else
                return false;
        }

        public static bool IsCustomerAddressMontlyFeePaid(this CustomerAccountAddress currentAddress)
        {
            if (currentAddress.PolicySubscriptions.FirstOrDefault() != null && currentAddress.PolicySubscriptions.Count() >= 1)
            {
                PolicySubscription currentSubsriptionPolicy = currentAddress.PolicySubscriptions.FirstOrDefault();

                return DateTime.Now.Date <= currentSubsriptionPolicy.NextMonthlyFeePaymentDate.Date;
            }

            else
                return false;
        }

        public static PolicySubscription ApplyMembershipPolicyOnCustomerAddress(this CustomerAccountAddress currentAddress,
            MembershipPolicy currentPolicy,
            DateTime subscriptionDate, DateTime nextRenewalDate, DateTime nextMonthlyFeePaymentDate)
        {
            PolicySubscription newPolicySubscription = new PolicySubscription();
            newPolicySubscription.GUID = Guid.NewGuid().ToString();
            newPolicySubscription.PolicyGUID = currentPolicy.GUID;
            newPolicySubscription.CustomerAccountAddressGUID = currentAddress.GUID;
            newPolicySubscription.SubscriptionDate = subscriptionDate;
            newPolicySubscription.NextRenewalDate = nextRenewalDate;
            newPolicySubscription.NextMonthlyFeePaymentDate = nextMonthlyFeePaymentDate;

            newPolicySubscription.MembershipPolicy = currentPolicy;
            newPolicySubscription.CustomerAccountAddress = currentAddress;

            return newPolicySubscription;
        }

        public static void UpdateMemberhipPolicyOnCustomerAddress(this CustomerAccountAddress currentAddress,
            PolicySubscription subscribedPolicy, MembershipPolicy policyToAssign, 
            DateTime nextRenewalDate, DateTime nextMonthlyFeePaymentDate)
        {
            subscribedPolicy.PolicyGUID = policyToAssign.GUID;
            subscribedPolicy.CustomerAccountAddressGUID = currentAddress.GUID;
            subscribedPolicy.NextRenewalDate = nextRenewalDate;
            subscribedPolicy.NextMonthlyFeePaymentDate = nextMonthlyFeePaymentDate;

            subscribedPolicy.MembershipPolicy = policyToAssign;
            subscribedPolicy.CustomerAccountAddress = currentAddress;
        }

        public static decimal AddDaysToRenewalDate(this CustomerAccountAddress currentAddress, int numberOfMonths)
        {
            decimal returnValue = 0.0M;

            if (currentAddress.PolicySubscriptions.FirstOrDefault() != null && currentAddress.PolicySubscriptions.Count() >= 1)
            {
                PolicySubscription currentSubsriptionPolicy = currentAddress.PolicySubscriptions.FirstOrDefault();

                int numberOfRenewal = numberOfMonths / currentSubsriptionPolicy.MembershipPolicy.MembershipMaturityInMonths;

                if (numberOfMonths > 0)
                    returnValue += numberOfRenewal * currentSubsriptionPolicy.MembershipPolicy.MembershipFee;

                returnValue += currentSubsriptionPolicy.MembershipPolicy.MonthlyFee * numberOfMonths;

                return returnValue;
            }

            else
                return returnValue;
        }
    }
}
