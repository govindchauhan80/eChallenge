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
    public class GiftController : ApiController
    {

        readonly GiftRepository giftRepository;

        public GiftController()
        {
            giftRepository = new GiftRepository();
        }

        /// <summary>
        /// Gets All the Gifts for Anonymous user
        /// </summary>
        /// <returns></returns>
        public ICollection<Gift> GetAllGifts()
        {
            return giftRepository.GetAllGifts();
        }

        /// <summary>
        /// Gets Challenge Cagegory by challenge category Id
        /// </summary>
        /// <param name="giftId"></param>
        /// <returns></returns>
        public Gift GetChallengeByGiftId(int giftId)
        {
            return giftRepository.GetChallengeByGiftId(giftId);
        }

        /// <summary>
        /// Creates a new Gift
        /// </summary>
        /// <param name="model"></param>
        public int CreateGift(Gift model)
        {
            giftRepository.CreateGift(model);
            return 1;
        }

        /// <summary>
        /// Updates a Gift
        /// </summary>
        /// <param name="model"></param>
        public int UpdateGift(Gift model)
        {
            giftRepository.UpdateGift(model);
            return 1;
        }

        /// <summary>
        /// Marks a Gift as deleted
        /// </summary>
        /// <param name="giftId"></param>
        public int DeleteGift(int giftId)
        {
            giftRepository.DeleteGift(giftId);
            return 1;
        }
    }
}
