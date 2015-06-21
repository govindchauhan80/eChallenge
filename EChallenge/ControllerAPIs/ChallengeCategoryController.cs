using EChallenge.Models;
using EChallenge.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EChallenge.ControllerAPIs
{
    public class ChallengeCategoryController : ApiController
    {
        readonly ChallengeCategoryRepository challengeCategoryRepository;

        public ChallengeCategoryController()
        {
            challengeCategoryRepository = new ChallengeCategoryRepository();
        }

        /// <summary>
        /// Gets All the challenges for Anonymous user
        /// </summary>
        /// <returns></returns>
        public ICollection<ChallengeCategory> GetAllChallengeCategories()
        {
            return challengeCategoryRepository.GetAllChallengeCategories();
        }

        /// <summary>
        /// Gets Challenge Cagegory by challenge category Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ChallengeCategory GetChallengeByChallengeCategoryId(int categoryId)
        {
            return challengeCategoryRepository.GetChallengeByChallengeCategoryId(categoryId);
        }

        /// <summary>
        /// Gets all challengeCategories created by current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<Challenge> GetChallengesByUserId(int userId)
        {
            return challengeCategoryRepository.GetChallengesByUserId(userId);
        }

        /// <summary>
        /// Creates a new challenge Category
        /// </summary>
        /// <param name="model"></param>
        public int CreateChallengeCategory(ChallengeCategory model)
        {
            challengeCategoryRepository.CreateChallengeCategory(model);
            return 1;
        }

        /// <summary>
        /// Updates a challengeCategory
        /// </summary>
        /// <param name="model"></param>
        public int UpdateChallengeCategory(ChallengeCategory model)
        {
            challengeCategoryRepository.UpdateChallengeCategory(model);
            return 1;
        }

        /// <summary>
        /// Marks a challenge as deleted
        /// </summary>
        /// <param name="ChallengeCategoryId"></param>
        public int DeleteChallengeCategories(int ChallengeCategoryId)
        {
            challengeCategoryRepository.DeleteChallengeCategories(ChallengeCategoryId);
            return 1; 
        }
    }
}
