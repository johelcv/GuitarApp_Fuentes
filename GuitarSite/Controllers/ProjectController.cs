using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guitar.BL;
using Guitar.Entities;
using GuitarSite.Models;
using AutoMapper;
using System.IO;
using System.Web.UI;

namespace GuitarSite.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private IGuitarService GuitarService;//  = new GuitarService();

        //Agregando el Dependency Injection
        //--------------------------------------------------------
        public ProjectController(IGuitarService GuitarService)
        {
            this.GuitarService = GuitarService;
        }
        //--------------------------------------------------------

        // GET: Project
        public ActionResult Index()
        {
            var model = this.GuitarService.GetAllProjects();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.GuitarBody = this.GuitarService.GetAllGuitarBodys();
            ViewBag.GuitarNeck = this.GuitarService.GetAllGuitarNecks();
            ViewBag.GuitarBridge = this.GuitarService.GetAllGuitarBridges();
            ViewBag.GuitarPickup = this.GuitarService.GetAllGuitarPickups();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project model, HttpPostedFileBase files)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.GuitarBody = this.GuitarService.GetAllGuitarBodys();
                ViewBag.GuitarNeck = this.GuitarService.GetAllGuitarNecks();
                ViewBag.GuitarBridge = this.GuitarService.GetAllGuitarBridges();
                ViewBag.GuitarPickup = this.GuitarService.GetAllGuitarPickups();
                return View(model);
            }

            if (files != null)
            {

                var fileName = string.Format("/Images/{0}",
                    "Guitar_" + string.Format("{0:HHmmssfff}", DateTime.Now) + Path.GetExtension(files.FileName));
                files.SaveAs(this.Server.MapPath(fileName));
                model.ImgProject = fileName;
            }

            this.GuitarService.Create(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = this.GuitarService.GetOne(id);

            ViewBag.GuitarBody = this.GuitarService.GetAllGuitarBodys();
            ViewBag.GuitarNeck = this.GuitarService.GetAllGuitarNecks();
            ViewBag.GuitarBridge = this.GuitarService.GetAllGuitarBridges();
            ViewBag.GuitarPickup = this.GuitarService.GetAllGuitarPickups();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project model)
        {
            if (!ModelState.IsValid)
            {
                // fetch the guitar body(and extras) again to populate the dropdowns
                ViewBag.GuitarBody = this.GuitarService.GetAllGuitarBodys();
                ViewBag.GuitarNeck = this.GuitarService.GetAllGuitarNecks();
                ViewBag.GuitarBridge = this.GuitarService.GetAllGuitarBridges();
                ViewBag.GuitarPickup = this.GuitarService.GetAllGuitarPickups();
                return View(model);
            }

            this.GuitarService.Update(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            var model = this.GuitarService.GetOne(id);

            ProjectViewModel projectVM = Mapper.Map<Project, ProjectViewModel>(model);

            return View(projectVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,ProjectViewModel Model)
        {
            var model = this.GuitarService.GetOne(id);

            model.Id = id;
            this.GuitarService.Delete(model);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = this.GuitarService.GetOne(id);

            ProjectViewModel projectVM = Mapper.Map<Project, ProjectViewModel>(model);

            return View(projectVM);
        }

        [OutputCache(Duration = 2400,
            VaryByParam = "*",
            Location = OutputCacheLocation.Client)]
        public ActionResult GetGuitarImg(int Id)
        {
            var model = this.GuitarService.GetOne(Id);
            return this.File(model.ImgProject,
                string.Format("image/{0}",
                Path.GetExtension(model.ImgProject)));
        }

    }
}