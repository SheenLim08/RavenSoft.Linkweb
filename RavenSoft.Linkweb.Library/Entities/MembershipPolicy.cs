//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RavenSoft.Linkweb.Library.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class MembershipPolicy
    {
        public MembershipPolicy()
        {
            this.PolicySubscriptions = new HashSet<PolicySubscription>();
        }
    
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal MembershipFee { get; set; }
        public decimal WayBillCharge { get; set; }
        public int MaxPickupWayBillPerMonth { get; set; }
        public int MaxDeliveryWayBillPerMonth { get; set; }
        public int MaxBillEntries { get; set; }
        public decimal Insurance { get; set; }
        public int MembershipMaturityInMonths { get; set; }
        public decimal PenaltyCharge { get; set; }
    
        public virtual ICollection<PolicySubscription> PolicySubscriptions { get; set; }
    }
}
