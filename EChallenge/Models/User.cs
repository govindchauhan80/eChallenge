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
    
    public partial class User
    {
        public User()
        {
            this.ChallengeRankings = new HashSet<ChallengeRanking>();
            this.UserChallenges = new HashSet<UserChallenge>();
            this.UserChallengeRankings = new HashSet<UserChallengeRanking>();
            this.UserGiftRedemptions = new HashSet<UserGiftRedemption>();
            this.UserRoles = new HashSet<UserRole>();
        }
    
        public decimal UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public string DisplayName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<decimal> Pincode { get; set; }
        public string Provider { get; set; }
        public string ProfilePicUrl { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatesDate { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<ChallengeRanking> ChallengeRankings { get; set; }
        public virtual ICollection<UserChallenge> UserChallenges { get; set; }
        public virtual ICollection<UserChallengeRanking> UserChallengeRankings { get; set; }
        public virtual ICollection<UserGiftRedemption> UserGiftRedemptions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
