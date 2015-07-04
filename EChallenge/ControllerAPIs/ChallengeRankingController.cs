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
    public class ChallengeRankingController : ApiController
    {
        ChallengeRankingRepository challengeRankingRepository;
        public ChallengeRankingController()
        {
            challengeRankingRepository = new ChallengeRankingRepository();
        }

        /// <summary>
        /// Gets all challege and their ranking
        /// </summary>
        /// <returns></returns>
        public ICollection<ChallengeRankingViewModel> GetAllChallengeRanking()
        {
            return challengeRankingRepository.GetAllChallengeRanking();
        }

        /// <summary>
        /// Gets ranking of a challenge
        /// </summary>
        /// <param name="challengeId"></param>
        /// <returns></returns>
        public ICollection<ChallengeRanking> GetChallengeRankingByChallengeId(int challengeId)
        {
            return challengeRankingRepository.GetChallengeRankingByChallengeId(challengeId);
        }

        /// <summary>
        /// Adds challenge ranking
        /// </summary>
        /// <param name="model"></param>
        public bool AddUserChallengeRanking(ChallengeRanking model)
        {
            challengeRankingRepository.AddUserChallengeRanking(model);
            return true;
        }

        /// <summary>
        /// Updates challenge ranking
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateChallengeRanking(ChallengeRanking model)
        {
            challengeRankingRepository.UpdateChallengeRanking(model);
            return true;
        }

        /// <summary>
        /// Marks challenge ranking as deleted
        /// </summary>
        /// <param name="challengeRankingId"></param>
        public bool DeleteChallengeRanking(int challengeRankingId)
        {
            challengeRankingRepository.DeleteChallengeRanking(challengeRankingId);
            return true;
        }
    }
}
