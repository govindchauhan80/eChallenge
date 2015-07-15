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
    public class UserChallengeRankingController : ApiController
    {
        UserChallengeRankingRepository userChallengeRankingRepository;
        public UserChallengeRankingController()
        {
            userChallengeRankingRepository = new UserChallengeRankingRepository();
        }

        /// <summary>
        /// Gets all user challenge ranking
        /// </summary>
        /// <returns></returns>
        public ICollection<UserRankingViewModel> GetAllUserChallengeRanking()
        {
            return userChallengeRankingRepository.GetAllUserChallengeRanking();
        }

        /// <summary>
        /// Gets user challenge ranking  by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<UserChallengeRanking> GetUserChallengeRankingByUserId(int userId)
        {
            return userChallengeRankingRepository.GetUserChallengeRankingByUserId(userId);
        }

        /// <summary>
        /// Adds a user challenge ranking
        /// </summary>
        /// <param name="model"></param>
        public bool AddUserChallengeRanking(UserChallengeRanking model)
        {
            userChallengeRankingRepository.AddUserChallengeRanking(model);
            return true;
        }

        /// <summary>
        /// Updates user challenge ranking
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateUserChallengeRanking(UserChallengeRanking model)
        {
            userChallengeRankingRepository.UpdateUserChallengeRanking(model);
            return true;
        }

        /// <summary>
        /// Deletes a user challenge ranking
        /// </summary>
        /// <param name="userChallengeRankingId"></param>
        public bool DeleteUserChallengeRanking(int userChallengeRankingId)
        {
            userChallengeRankingRepository.DeleteUserChallengeRanking(userChallengeRankingId);
            return true;
        }
    }
}
