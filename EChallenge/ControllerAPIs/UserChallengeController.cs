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
    public class UserChallengeController : ApiController
    {
        readonly UserChallengeRepository userCahllengeRepository;

        public UserChallengeController()
        {
            userCahllengeRepository = new UserChallengeRepository();
        }

        public ICollection<UserChallenge> GetAllChallengeByUserId(int userId)
        {
            return userCahllengeRepository.GetAllChallengeByUserId(userId);
        }

        public ICollection<UserChallenge> GetAllUserByChallengeId(int challengeId)
        {
            return userCahllengeRepository.GetAllUserByChallengeId(challengeId);
        }

        public int AddChallengeForUser(UserChallenge model)
        {
            userCahllengeRepository.AddChallengeForUser(model);
            return 1;
        }

        public int ApproveChallenge(int userChallengeId)
        {
            userCahllengeRepository.ApproveChallenge(userChallengeId);
            return 1;
        }
    }
}
