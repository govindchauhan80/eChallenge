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
            User user = (User)Session["User"];
            myRedemptionsViewModel.GiftsAvailableForRedemption = userGiftRedemptionAPI.GetGiftsAvailableForUser(Convert.ToInt32(user.UserId));
            myRedemptionsViewModel.GiftsAvailed = userGiftRedemptionAPI.GetAllGiftRedemptionForUser(Convert.ToInt32(user.UserId));
            return View(myRedemptionsViewModel);
        }
    }
}