using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class UserChallengeRankingRepository
    {

        public ICollection<UserRankingViewModel> GetAllUserChallengeRanking()
        {
            var entities = new EChallengeEntities();
            return (from ucr in entities.UserChallengeRankings
                    group ucr by ucr.UserId into g
                    select new UserRankingViewModel
                    {
                        UserId = (int)g.Select(ucr => ucr.UserId).FirstOrDefault(),
                        UserRanking = (double)g.Average(ucr => ucr.Ranking),
                        User = g.Select(ucr => ucr.User).FirstOrDefault()
                    }).ToList();
        }


        public ICollection<UserChallengeRanking> GetUserChallengeRankingByUserId(int userId)
        {
            var entities = new EChallengeEntities();
            return entities.UserChallengeRankings.Where(c => c.UserId == userId).ToList();
        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="model"></param>
        public void AddUserChallengeRanking(UserChallengeRanking model)
        {
            model.RankingDate = DateTime.Now;
            using (var entities = new EChallengeEntities())
            {
                entities.UserChallengeRankings.Add(model);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a User
        /// </summary>
        /// <param name="model"></param>
        public void UpdateUserChallengeRanking(UserChallengeRanking model)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingUserRanking = entities.UserChallengeRankings.Where(c => c.UserChallengeRankingId == model.UserChallengeRankingId).FirstOrDefault();

                if (existingUserRanking == null)
                    throw new NullReferenceException("existingUserRanking not found");

                existingUserRanking.IsCompleted = model.IsCompleted;
                existingUserRanking.ChallengeId = model.ChallengeId;
                existingUserRanking.Ranking = model.Ranking;
                existingUserRanking.RankingDate = DateTime.UtcNow;
                existingUserRanking.UserId = model.UserId;
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Marks a User as deleted
        /// </summary>
        /// <param name="userChallengeRankingId"></param>
        public void DeleteUserChallengeRanking(int userChallengeRankingId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingUserRanking = entities.UserChallengeRankings.Where(c => c.UserChallengeRankingId == userChallengeRankingId).FirstOrDefault();

                if (existingUserRanking == null)
                    throw new NullReferenceException("User not found");

                entities.UserChallengeRankings.Remove(existingUserRanking);
                entities.SaveChanges();
            }
        }
    }
}