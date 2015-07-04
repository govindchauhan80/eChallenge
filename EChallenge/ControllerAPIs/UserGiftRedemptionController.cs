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
    public class UserGiftRedemptionController : ApiController
    {
        UserGiftRedemptionRepository userGiftRedemptionRepository;
        public UserGiftRedemptionController()
        {
            userGiftRedemptionRepository = new UserGiftRedemptionRepository();
        }

        /// <summary>
        /// Gets all gift redemprion by a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICollection<UserGiftRedemption> GetAllGiftRedemptionForUser(int userId)
        {
            return userGiftRedemptionRepository.GetAllGiftRedemptionForUser(userId);
        }

        /// <summary>
        /// Gets all gift redemtion
        /// </summary>
        /// <returns></returns>
        public ICollection<UserGiftRedemption> GetAllGiftRedemption()
        {
            return userGiftRedemptionRepository.GetAllGiftRedemption();
        }

        /// <summary>
        /// Adds a gift redemption of user
        /// </summary>
        /// <param name="model"></param>
        public bool AddUserGiftRedemption(UserGiftRedemption model)
        {
            userGiftRedemptionRepository.AddUserGiftRedemption(model);
            return true;
        }

        /// <summary>
        /// Updates a gift redemption of user
        /// </summary>
        /// <param name="model"></param>
        public bool UpdateUserGiftRedemption(UserGiftRedemption model)
        {
            userGiftRedemptionRepository.UpdateUserGiftRedemption(model);
            return true;
        }

        /// <summary>
        /// Deletes a gift redemption of user
        /// </summary>
        /// <param name="userGiftRedemptionId"></param>
        public bool DeleteUserGiftRedemption(int userGiftRedemptionId)
        {
            userGiftRedemptionRepository.DeleteUserGiftRedemption(userGiftRedemptionId);
            return true;
        }

    }
}
