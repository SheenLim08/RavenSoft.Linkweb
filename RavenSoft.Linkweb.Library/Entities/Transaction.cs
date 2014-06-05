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
    
    public partial class Transaction
    {
        public Transaction()
        {
            this.TransactionPayments = new HashSet<TransactionPayment>();
        }
    
        public string TransactionID { get; set; }
        public string CustomerGUID { get; set; }
        public string CustomerAccountAddressGUID { get; set; }
        public string BillingAccountID { get; set; }
        public string TransactionType { get; set; }
        public decimal PolicyWayBillCharge { get; set; }
        public string ServiceTypeGUID { get; set; }
        public decimal ServiceTypeCharge { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public decimal VATCharge { get; set; }
        public string BatchTransactionID { get; set; }
        public string Notes { get; set; }
    
        public virtual CustomerAccountAddress CustomerAccountAddress { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual ICollection<TransactionPayment> TransactionPayments { get; set; }
    }
}