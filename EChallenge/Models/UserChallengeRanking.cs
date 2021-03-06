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
    
    public partial class UserChallengeRanking
    {
        public UserChallengeRanking()
        {
            this.UserChallenges = new HashSet<UserChallenge>();
        }
    
        public decimal UserChallengeRankingId { get; set; }
        public Nullable<decimal> UserId { get; set; }
        public Nullable<int> Ranking { get; set; }
        public Nullable<decimal> ChallengeId { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<System.DateTime> RankingDate { get; set; }
    
        public virtual Challenge Challenge { get; set; }
        public virtual Challenge Challenge1 { get; set; }
        public virtual ICollection<UserChallenge> UserChallenges { get; set; }
        public virtual User User { get; set; }
    }
}
