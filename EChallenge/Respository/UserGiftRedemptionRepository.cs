using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class UserGiftRedemptionRepository
    {
        /// <summary>
        /// Gets all gift redemprion by a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<UserGiftRedemption> GetAllGiftRedemptionForUser(int userId)
        {
            var entities = new EChallengeEntities();
            return entities.UserGiftRedemptions.Where(ugr => ugr.UserId == userId).ToList();
        }

        /// <summary>
        /// Gets gifts available for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<Gift> GetGiftsAvailableForUser(int userId)
        {
            var entities = new EChallengeEntities();
            int pointsEarned = entities.UserChallengeRankings.Where(ucr => ucr.UserId == userId).Sum(ucr => ucr.Ranking) ?? default(int);
            int pointsAvailed = (int)(entities.UserGiftRedemptions.Where(ugr => ugr.UserId == userId).Sum(ugr => ugr.PointsConsumed) ?? default(int));

            var gifts = entities.Gifts.Where(g => !g.IsDeleted && g.Points <= (pointsEarned - pointsAvailed)).ToList();
            return gifts;
        }

        /// <summary>
        /// Gets all gift redemtion
        /// </summary>
        /// <returns></returns>
        public ICollection<UserGiftRedemption> GetAllGiftRedemption()
        {
            var entities = new EChallengeEntities();
            return entities.UserGiftRedemptions.ToList();
        }

        /// <summary>
        /// Adds a gift redemption of user
        /// </summary>
        /// <param name="model"></param>
        public void AddUserGiftRedemption(UserGiftRedemption model)
        {
            model.RedemptionDate = DateTime.UtcNow;
            using (var entities = new EChallengeEntities())
            {
                entities.UserGiftRedemptions.Add(model);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a gift redemption of user
        /// </summary>
        /// <param name="model"></param>
        public void UpdateUserGiftRedemption(UserGiftRedemption model)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingUserGiftRedemption = entities.UserGiftRedemptions.Where(c => c.UserGiftRedemptionId == model.UserGiftRedemptionId).FirstOrDefault();

                if (existingUserGiftRedemption == null)
                    throw new NullReferenceException("existingUserGiftRedemption not found");

                existingUserGiftRedemption.GiftId = model.GiftId;
                existingUserGiftRedemption.PointsConsumed = model.PointsConsumed;
                existingUserGiftRedemption.RedemptionDate = DateTime.UtcNow;
                existingUserGiftRedemption.UserId = model.UserId;
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a gift redemption of user
        /// </summary>
        /// <param name="userGiftRedemptionId"></param>
        public void DeleteUserGiftRedemption(int userGiftRedemptionId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingUserGiftRedemption = entities.UserGiftRedemptions.Where(c => c.UserGiftRedemptionId == userGiftRedemptionId).FirstOrDefault();

                if (existingUserGiftRedemption == null)
                    throw new NullReferenceException("existingUserGiftRedemption not found");

                entities.UserGiftRedemptions.Remove(existingUserGiftRedemption);
                entities.SaveChanges();
            }
        }
    }
}