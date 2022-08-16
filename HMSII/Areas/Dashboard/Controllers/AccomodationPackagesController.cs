using HMS.Services;
using HMSII.Areas.Dashboard.ViewModels;
using HMSII.Entities;
using HMSII.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMSII.Areas.Dashboard.Controllers
{
    public class AccomodationPackagesController : Controller
    {
        AccomodationPackageService accomodationPackageService = new AccomodationPackageService();
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();

        public ActionResult Index(string searchTerm, int? accomodationTypeID, int? page)
        {
            int pageSize = 5;
            page = page ?? 1;

            AccomodationPackageListingModel model = new AccomodationPackageListingModel();

            model.SearchTerm = searchTerm;

            model.AccomodationTypeID = accomodationTypeID;

            model.AccomodationPackages = accomodationPackageService.SearchAccomodationPackages(searchTerm, accomodationTypeID, page.Value, pageSize);

            model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();

            var totalPages = accomodationPackageService.SearchAccomodationPackagesCount(searchTerm, accomodationTypeID);

            model.Pager = new Pager(totalPages, page, pageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {

            AccomodationPackageActionModel model = new AccomodationPackageActionModel();

            if (ID.HasValue)
            {
                var accomodationPackage = accomodationPackageService.GetAccomodationPackageByID(ID.Value);

                model.ID = accomodationPackage.ID;
                model.AccomodationTypeID = accomodationPackage.AccomodationTypeID;
                model.Name = accomodationPackage.Name;
                model.NoOfRoom = accomodationPackage.NoOfRoom;
                model.FeePerNight = accomodationPackage.FeePerNight;

            }

            model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0) //we are trying to edit a record
            {
                var accomodationPackage = accomodationPackageService.GetAccomodationPackageByID(model.ID);

                accomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRoom = model.NoOfRoom;
                accomodationPackage.FeePerNight = model.FeePerNight;

                result = accomodationPackageService.UpdateAccomodationPackage(accomodationPackage);
            }
            else //we are trying to create a record
            {
                AccomodationPackage accomodationPackage = new AccomodationPackage();

                accomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRoom = model.NoOfRoom;
                accomodationPackage.FeePerNight = model.FeePerNight;

                result = accomodationPackageService.SaveAccomodationPackage(accomodationPackage);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Packages." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {

            AccomodationPackageActionModel model = new AccomodationPackageActionModel();

            var accomodationPackage = accomodationPackageService.GetAccomodationPackageByID(ID);

            model.ID = accomodationPackage.ID;

            return PartialView("_Delete", model);
        }


        [HttpPost]
        public JsonResult Delete(AccomodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationPackage = accomodationPackageService.GetAccomodationPackageByID(model.ID);

            result = accomodationPackageService.DeleteAccomodationPackage(accomodationPackage);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Packages." };
            }

            return json;
        }

    }
}