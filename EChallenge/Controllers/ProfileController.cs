using EChallenge.Models;
using EChallenge.Respository;
using System;
using System.Collections.Generic;
using System.IO;
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
                    model.ProfilePicUrl = ViewBag.ImageURL;
                    userRepository.UpdateUser(model);
                }
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 4; //Size = 4 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };
                    if (!AllowedFileExtensions.Contains
         (file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Images/Profile"), fileName);
                        ViewBag.ImageURL = path;
                        
                        file.SaveAs(path);
                        User model = (User)Session["User"];
                        UserRepository userRepository = new UserRepository();
                        model.ProfilePicUrl = ViewBag.ImageURL;
                        userRepository.UpdateUser(model);
                        ViewBag.Message = "File uploaded successfully.";
                      //  ViewBag.Keep();
                    }
                }
            }
            return RedirectToAction("Edit");
        }
    }
}
    