//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EChallenge.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserGiftRedemption
    {
        public decimal UserGiftRedemptionId { get; set; }
        public Nullable<decimal> UserId { get; set; }
        public Nullable<decimal> GiftId { get; set; }
        public Nullable<double> PointsConsumed { get; set; }
        public Nullable<System.DateTime> RedemptionDate { get; set; }
    
        public virtual Gift Gift { get; set; }
        public virtual User User { get; set; }
    }
}