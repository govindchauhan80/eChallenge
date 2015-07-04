using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class UserGiftRedemptionRepository
    {
        public ICollection<UserGiftRedemption> GetAllGiftRedemptionForUser(int userId)
        {
            var entities = new EChallengeEntities();
            return entities.UserGiftRedemptions.Where(ugr => ugr.UserId == userId).ToList();
        }

        public ICollection<UserGiftRedemption> GetAllGiftRedemptionByUser()
        {
            var entities = new EChallengeEntities();
            return entities.UserGiftRedemptions.ToList();
        }

        public void AddUserGiftRedemption(UserGiftRedemption model)
        {
            model.RedemptionDate = DateTime.UtcNow;
            using (var entities = new EChallengeEntities())
            {
                entities.UserGiftRedemptions.Add(model);
                entities.SaveChanges();
            }
        }

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