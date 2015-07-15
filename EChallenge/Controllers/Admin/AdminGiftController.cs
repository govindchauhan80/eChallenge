using EChallenge.ControllerAPIs;
using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EChallenge.Controllers.Admin
{
    public class AdminGiftController : Controller
    {
        GiftController giftController;

        public AdminGiftController()
        {
            giftController = new GiftController();
        }

        //
        // GET: /AdminGift/
        public ActionResult Index()
        {
            ICollection<Gift> lstGift = giftController.GetAllGifts();
            return View(lstGift);
        }

        //
        // GET: /AdminGift/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AdminGift/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminGift/Create
        [HttpPost]
        public ActionResult Create(Gift model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    model.ImagePath = ViewBag.ImageURL;
                    giftController.CreateGift(model);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminGift/Edit/5
        public ActionResult Edit(int id)
        {
            Gift gift = giftController.GetGiftByGiftId(id);
            return View(gift);
        }

        //
        // POST: /AdminGift/Edit/5
        [HttpPost]
        public ActionResult Edit(Gift model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    giftController.UpdateGift(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /AdminGift/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                giftController.DeleteGift(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
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
                        var path = Path.Combine(Server.MapPath("~/Content/Images/Gifts"), fileName);
                        ViewBag.ImageURL = path;
                        ViewBag.keep();
                        file.SaveAs(path);
                        ModelState.Clear();
                        ViewBag.Message = "File uploaded successfully. File path :   ~/Upload/" + fileName;
                    }
                }
            }
            return RedirectToAction("Create");
        }
    }
}
