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
    
    public partial class CustomerAccount
    {
        public CustomerAccount()
        {
            this.CustomerAccountAddresses = new HashSet<CustomerAccountAddress>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<CustomerAccountAddress> CustomerAccountAddresses { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
