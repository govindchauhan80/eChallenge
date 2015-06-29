using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ControllerAPIs.ChallengeController challengeController = new ControllerAPIs.ChallengeController();
            ControllerAPIs.GiftController giftController = new ControllerAPIs.GiftController();
            List<Challenge> challenge = challengeController.GetAllChallenges().ToList();
            ViewBag.ActiveChallenge = challenge;
            List<Gift> lstGift = giftController.GetAllGifts().ToList();
            ViewBag.Gifts = lstGift;
            List<ChallengeRanking> lstRanking = new List<ChallengeRanking>();

            return View();
        }

    }
}