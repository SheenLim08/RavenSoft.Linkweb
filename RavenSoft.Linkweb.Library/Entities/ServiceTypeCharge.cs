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
    
    public partial class ServiceTypeCharge
    {
        public string GUID { get; set; }
        public int IndexLocation { get; set; }
        public string ServiceTypeGUID { get; set; }
        public decimal Amount { get; set; }
        public decimal Charge { get; set; }
    
        public virtual ServiceType ServiceType { get; set; }
    }
}
