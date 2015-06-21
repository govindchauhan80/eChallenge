using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EChallenge.Services;

namespace EChallenge.Respository
{
    public class UserChallengeRepository
    {
        public ICollection<UserChallenge> GetAllChallengeByUserId(int userId)
        {
            using (var entities = new EChallengeEntities())
            {
                return entities.UserChallenges.Where(c => c.UserId == userId).ToList();
            }
        }

        public ICollection<UserChallenge> GetAllUserByChallengeId(int challengeId)
        {
            using (var entities = new EChallengeEntities())
            {
                return entities.UserChallenges.Where(c => c.ChallengeId == challengeId).ToList();
            }
        }

        public void AddChallengeForUser(UserChallenge model)
        {
            using (var entities = new EChallengeEntities())
            {
                model.ChallengeTakenDate = DateTime.UtcNow;
                model.ChallengeStatus = ChallengeStatus.InComplete.ToString();
                entities.UserChallenges.Add(model);
                entities.SaveChanges();
            }
        }

        public void ApproveChallenge(int userChallengeId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingChallenge = entities.UserChallenges.Where(uc => uc.UserChallengeId == userChallengeId).FirstOrDefault();
                if (existingChallenge == null)
                    throw new NullReferenceException(string.Format("No Challenge Found for userChallengeId : {0}", userChallengeId));

                existingChallenge.IsApproved = true;
                entities.SaveChanges();
            }
        }
    }
}