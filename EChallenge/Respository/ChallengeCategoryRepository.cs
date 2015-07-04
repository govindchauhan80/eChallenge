using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class ChallengeCategoryRepository
    {
        /// <summary>
        /// Gets All the challenges for Anonymous user
        /// </summary>
        /// <returns></returns>
        public ICollection<ChallengeCategory> GetAllChallengeCategories()
        {
            var entities = new EChallengeEntities();
            return entities.ChallengeCategories.Where(c => !c.IsDeleted).ToList();

        }

        /// <summary>
        /// Gets Challenge Cagegory by challenge category Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ChallengeCategory GetChallengeCategoryByChallengeCategoryId(int categoryId)
        {
            var entities = new EChallengeEntities();
            return entities.ChallengeCategories.Where(c => !c.IsDeleted && c.ChallengeCategoryId == categoryId).FirstOrDefault();
        }
               
        /// <summary>
        /// Creates a new challenge Category
        /// </summary>
        /// <param name="model"></param>
        public void CreateChallengeCategory(ChallengeCategory model)
        {
            using (var entities = new EChallengeEntities())
            {
                model.CreatedDate = DateTime.UtcNow;
                model.UpdatedDate = DateTime.UtcNow;
                entities.ChallengeCategories.Add(model);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a challengeCategory
        /// </summary>
        /// <param name="model"></param>
        public void UpdateChallengeCategory(ChallengeCategory model)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingChallengeCategory = entities.ChallengeCategories.Where(c => !c.IsDeleted && c.ChallengeCategoryId == model.ChallengeCategoryId).FirstOrDefault();

                if (existingChallengeCategory == null)
                    throw new NullReferenceException("challengeCategory not found");

                existingChallengeCategory.Title = model.Title;
                existingChallengeCategory.UpdatedDate = DateTime.UtcNow;

                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Marks a challenge as deleted
        /// </summary>
        /// <param name="ChallengeCategoryId"></param>
        public void DeleteChallengeCategories(int ChallengeCategoryId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingChallengeCategory = entities.ChallengeCategories.Where(c => !c.IsDeleted && c.ChallengeCategoryId == ChallengeCategoryId).FirstOrDefault();

                if (existingChallengeCategory == null)
                    throw new NullReferenceException("challengeCategory not found");

                existingChallengeCategory.IsDeleted = true;
                entities.SaveChanges();
            }
        }
    }
}