using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class GiftRepository
    {
        /// <summary>
        /// Gets All the Gifts for Anonymous user
        /// </summary>
        /// <returns></returns>
        public ICollection<Gift> GetAllGifts()
        {
            using (var entities = new EChallengeEntities())
            {
                return entities.Gifts.Where(c => !c.IsDeleted).ToList();
            }
        }

        /// <summary>
        /// Gets Challenge Cagegory by challenge category Id
        /// </summary>
        /// <param name="giftId"></param>
        /// <returns></returns>
        public Gift GetChallengeByGiftId(int giftId)
        {
            using (var entities = new EChallengeEntities())
            {
                return entities.Gifts.Where(c => !c.IsDeleted && c.GiftId == giftId).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets all Gifts created by current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<Challenge> GetChallengesByUserId(int userId)
        {
            using (var entities = new EChallengeEntities())
            {
                return entities.Challenges.Where(c => !c.IsDeleted && c.CreatedBy == userId).ToList();
            }
        }

        /// <summary>
        /// Creates a new Gift
        /// </summary>
        /// <param name="model"></param>
        public void CreateGift(Gift model)
        {
            using (var entities = new EChallengeEntities())
            {
                model.CreatedDate = DateTime.UtcNow;
                model.UpdatedDate = DateTime.UtcNow;
                entities.Gifts.Add(model);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a Gift
        /// </summary>
        /// <param name="model"></param>
        public void UpdateGift(Gift model)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingGift = entities.Gifts.Where(c => !c.IsDeleted && c.GiftId == model.GiftId).FirstOrDefault();

                if (existingGift == null)
                    throw new NullReferenceException("Gift not found");

                existingGift.Title = model.Title;
                existingGift.UpdatedDate = DateTime.UtcNow;

                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Marks a Gift as deleted
        /// </summary>
        /// <param name="giftId"></param>
        public void DeleteGift(int giftId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingGift = entities.Gifts.Where(c => !c.IsDeleted && c.GiftId == giftId).FirstOrDefault();

                if (existingGift == null)
                    throw new NullReferenceException("Gift not found");

                existingGift.IsDeleted = true;
                entities.SaveChanges();
            }
        }
    }
}