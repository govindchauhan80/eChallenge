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
        public ChallengeCategory GetChallengeCategoryByChallengeCategoryId(int categoryId)
        {
            return challengeCategoryRepository.GetChallengeCategoryByChallengeCategoryId(categoryId);
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
