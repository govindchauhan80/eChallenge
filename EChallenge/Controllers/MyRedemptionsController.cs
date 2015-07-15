using EChallenge.ControllerAPIs;
using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EChallenge.Controllers
{
    public class MyRedemptionsController : Controller
    {
        UserGiftRedemptionController userGiftRedemptionAPI;

        public MyRedemptionsController()
        {
            userGiftRedemptionAPI = new UserGiftRedemptionController();
        }
        // GET: MyRedemptions
        public ActionResult Index()
        {
            MyRedemptionsViewModel myRedemptionsViewModel = new MyRedemptionsViewModel();
            myRedemptionsViewModel.GiftsAvailableForRedemption = userGiftRedemptionAPI.GetGiftsAvailableForUser(4);
            myRedemptionsViewModel.GiftsAvailed = userGiftRedemptionAPI.GetAllGiftRedemptionForUser(4);
            return View(myRedemptionsViewModel);
        }
    }
}