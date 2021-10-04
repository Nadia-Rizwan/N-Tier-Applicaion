using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace UI.Areas.User.Controllers
{
    public class ProfilesController : Controller
    {
         //private StoredProcedureDBEntities db = new StoredProcedureDBEntities();
        private ProfilesBS ObjBs;

        public ProfilesController()
        {
            ObjBs = new ProfilesBS();

        }

        //GET: User/Profiles
        public ActionResult Index()
        {
            return View(ObjBs.GetAll());

          
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(Profile profile)
        {
            try
            {
                if (profile.Profile_ID == 0)
                {
                    ObjBs.Delete(0);


                }
                var ProfileList = ObjBs.GetAll().ToList();

                if (ModelState.IsValid)
                {

                    ObjBs.Insert(profile);
                }
                else
                {


                    return View(profile);


                }

            }
            catch (Exception ex)
            {
                TempData["Msg"] = "reccord created failed" + ex.Message;
                return RedirectToAction("Create");


            }


            return View();


        }
        public ActionResult Edit(int id)

        {

            var profileID = ObjBs.GetByIdBS(id);
            try
            {



                if (profileID == null)
                {
                    return HttpNotFound();
                }


            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Erorr:" + ex.Message;
                return RedirectToAction("Edit");


            }
            // ViewBag.Profile_Id = new SelectList(db.Profiles, "Profile_Id", "FirstName_");

            return View(profileID);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profile profile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ObjBs.Update(profile);
                    return RedirectToAction("Index");
                }
                else
                {

                    return View(profile);
                }
            }

            catch (Exception ex)
            {

                TempData["Msg"] = "reccord edit failed" + ex.Message;
                return RedirectToAction("Edit");




            }

        }


        public ActionResult Delete(int id)
        {
            try
            {


                var profileID = ObjBs.GetByIdBS(id);
                if (profileID == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(profileID);

                }


            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Erorr:" + ex.Message;
                return RedirectToAction("Index");


            }

        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var profileID = ObjBs.GetByIdBS(id);
                ObjBs.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "reccord created failed" + ex.Message;
                return RedirectToAction("Index");


            }
        }





    }
}
