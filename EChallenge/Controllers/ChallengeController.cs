using EChallenge.Models;
using EChallenge.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EChallenge.Controllers
{
    public class ChallengeController : Controller
    {
        //
        // GET: /Challenge/
        public ActionResult Index()
        {
            ChallengeCategoryRepository ccR = new ChallengeCategoryRepository();
            List<ChallengeCategory> CC = ccR.GetAllChallengeCategories().ToList();
            
            return View(CC);
        }

        //
        // GET: /Challenge/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Challenge/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Challenge/Create
        [HttpPost]
        public ActionResult Create(Challenge model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    ChallengeRepository challengeRepository = new ChallengeRepository();
                    challengeRepository.CreateChallenge(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Challenge/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Challenge/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
