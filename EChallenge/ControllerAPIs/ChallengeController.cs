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
    public class ChallengeController : ApiController
    {
        readonly ChallengeRepository challengeRepository;

        public ChallengeController()
        {
            challengeRepository = new ChallengeRepository();
        }

        /// <summary>
        /// Gets All the challenges for Anonymous user
        /// </summary>
        /// <returns></returns>
        public ICollection<Challenge> GetAllChallenges()
        {
            return challengeRepository.GetAllChallenges();
        }

        /// <summary>
        /// Gets challenge by challengeId
        /// </summary>
        /// <param name="challengeId"></param>
        /// <returns></returns>
        public Challenge GetChallengeByChallengeId(int challengeId)
        {
            return challengeRepository.GetChallengeByChallengeId(challengeId);
        }

        /// <summary>
        /// Gets all challenges created by current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<Challenge> GetChallengesByUserId(int userId)
        {
            return challengeRepository.GetChallengesByUserId(userId);
        }

        /// <summary>
        /// Gets all challenges by categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ICollection<Challenge> GetChallengesByCategoryId(int categoryId)
        {
            return challengeRepository.GetChallengesByCategoryId(categoryId);
        }

        /// <summary>
        /// Creates a new challenge
        /// </summary>
        /// <param name="model"></param>
        public int CreateChallenge(Challenge model)
        {
            challengeRepository.CreateChallenge(model);
            return 1;
        }

        /// <summary>
        /// Updates a challenge
        /// </summary>
        /// <param name="model"></param>
        public int UpdateChallenge(Challenge model)
        {
            challengeRepository.UpdateChallenge(model);
            return 1;
        }

        /// <summary>
        /// Marks a challenge as deleted
        /// </summary>
        /// <param name="ChallengeId"></param>
        public int DeleteChallenge(int ChallengeId)
        {
            challengeRepository.DeleteChallenge(ChallengeId);
            return 1;
        }
    }
}
