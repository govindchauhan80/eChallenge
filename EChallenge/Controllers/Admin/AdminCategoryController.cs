using EChallenge.ControllerAPIs;
using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EChallenge.Controllers.Admin
{
    public class AdminCategoryController : Controller
    {
        ChallengeCategoryController challengeCategoryController;

        public AdminCategoryController()
        {
            challengeCategoryController = new ChallengeCategoryController();
        }
        //
        // GET: /AdminCategory/
        public ActionResult Index()
        {
            ICollection<ChallengeCategory> lstChallenegeCategory = challengeCategoryController.GetAllChallengeCategories();
            return View(lstChallenegeCategory);
        }

        //
        // GET: /AdminCategory/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        //
        // GET: /AdminCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminCategory/Create
        [HttpPost]
        public ActionResult Create(ChallengeCategory model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    challengeCategoryController.CreateChallengeCategory(model);
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
        // GET: /AdminCategory/Edit/5
        public ActionResult Edit(int id)
        {
            //ChallengeCategory challengeCategory = challengeCategoryController.GetChallengeByChallengeCategoryId(id);
            return View();
        }

        //
        // POST: /AdminCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(ChallengeCategory model)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    challengeCategoryController.UpdateChallengeCategory(model);
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
        // POST: /AdminCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                challengeCategoryController.DeleteChallengeCategories(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
