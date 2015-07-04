using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class ChallengeRepository
    {
        /// <summary>
        /// Gets All the challenges for Anonymous user
        /// </summary>
        /// <returns></returns>
        public ICollection<Challenge> GetAllChallenges()
        {
            var entities = new EChallengeEntities();
            return entities.Challenges.Where(c => !c.IsDeleted).ToList();
        }

        /// <summary>
        /// Gets challenge by challengeId
        /// </summary>
        /// <param name="challengeId"></param>
        /// <returns></returns>
        public Challenge GetChallengeByChallengeId(int challengeId)
        {
            var entities = new EChallengeEntities();
            return entities.Challenges.Where(c => !c.IsDeleted && c.ChallengeId == challengeId && c.ExpiryDate >= DateTime.UtcNow).FirstOrDefault();
        }

        /// <summary>
        /// Gets all challenges created by current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<Challenge> GetChallengesByUserId(int userId)
        {
            var entities = new EChallengeEntities();
            return entities.Challenges.Where(c => !c.IsDeleted && c.CreatedBy == userId).ToList();
        }

        /// <summary>
        /// Gets all challenges by categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ICollection<Challenge> GetChallengesByCategoryId(int categoryId)
        {
            var entities = new EChallengeEntities();
            return entities.Challenges.Where(c => !c.IsDeleted && c.ChallengeCategoryId == categoryId && c.ExpiryDate >= DateTime.UtcNow).ToList();
        }

        /// <summary>
        /// Creates a new challenge
        /// </summary>
        /// <param name="model"></param>
        public void CreateChallenge(Challenge model)
        {
            using (var entities = new EChallengeEntities())
            {
                model.CreatedDated = DateTime.UtcNow;
                model.UpdatedDate = DateTime.UtcNow;
                entities.Challenges.Add(model);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a challenge
        /// </summary>
        /// <param name="model"></param>
        public void UpdateChallenge(Challenge model)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingChallenge = entities.Challenges.Where(c => !c.IsDeleted && c.ChallengeId == model.ChallengeId).FirstOrDefault();

                if (existingChallenge == null)
                    throw new NullReferenceException("Challenge not found");

                existingChallenge.ChallengeCategoryId = model.ChallengeCategoryId;
                existingChallenge.ChallengeImagePath = model.ChallengeImagePath;
                existingChallenge.Title = model.Title;
                existingChallenge.TimeLimit = model.TimeLimit;
                existingChallenge.SupportingDocumentPath = model.SupportingDocumentPath;
                existingChallenge.SupportingDocumentType = model.SupportingDocumentType;
                existingChallenge.ExpiryDate = model.ExpiryDate;
                existingChallenge.PersonsRequired = model.PersonsRequired;
                existingChallenge.Precautions = model.Precautions;
                existingChallenge.Severity = model.Severity;
                existingChallenge.Steps = model.Steps;
                existingChallenge.UpdatedDate = DateTime.UtcNow;

                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Marks a challenge as deleted
        /// </summary>
        /// <param name="ChallengeId"></param>
        public void DeleteChallenge(int ChallengeId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingChallenge = entities.Challenges.Where(c => !c.IsDeleted && c.ChallengeId == ChallengeId).FirstOrDefault();

                if (existingChallenge == null)
                    throw new NullReferenceException("Challenge not found");

                existingChallenge.IsDeleted = true;
                entities.SaveChanges();
            }
        }
    }
}