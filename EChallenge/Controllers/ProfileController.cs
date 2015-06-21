using EChallenge.Models;
using EChallenge.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EChallenge.Controllers
{
    public class ProfileController : Controller
    {
        
        public ActionResult Details()
        {
            UserRepository userRepository = new UserRepository();
            User TempUser = new User();
            TempUser = userRepository.GetUserByUserId(3);
            Session["User"] = TempUser;
            User user = new User();
            user = (User)Session["User"];
            user.DOB = user.DOB.Date;
            return View(user);
        }

        public ActionResult Edit()
        {
            User user = new User();
            user = (User)Session["User"];
            user.DOB = user.DOB.Date;
            return View(user);
        }

        //
        // POST: /Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    UserRepository userRepository = new UserRepository();
                    userRepository.UpdateUser(model);
                }
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }
    }
}
