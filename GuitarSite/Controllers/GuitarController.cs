using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guitar.BL;
using Guitar.Entities;

namespace GuitarSite.Controllers
{
    [Authorize]
    public class GuitarController : Controller
    {
        private IGuitarService GuitarService; // =  new GuitarService();

        //Agregando el Dependency Injection
        //--------------------------------------------------------
        public GuitarController(IGuitarService GuitarService)
        {
            this.GuitarService = GuitarService;
        }
        //--------------------------------------------------------

        // GET: Guitar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Projects = this.GuitarService.GetAllProjects();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guitar.Entities.Guitars Model, string FInicio, string FPintura, string FPrueba, string FFin)
        {
            //String FInicio, FPintura, FPrueba, FFin;
            var model = this.GuitarService.GetOne(Convert.ToInt32(Model.Name));

            Model.Name = model.Name;
            Model.BodyID = model.BodyID;
            Model.BridgeID = model.BridgeID;
            Model.NeckID = model.NeckID;
            Model.PickupID = model.PickupID;

            Model.StartDate = Convert.ToDateTime(FInicio); 
            Model.PaintDate = Convert.ToDateTime(FPintura);
            Model.TestDate = Convert.ToDateTime(FPrueba);
            Model.FinishDate = Convert.ToDateTime(FFin);

            if (!ModelState.IsValid)
            {
                ViewBag.Projects = this.GuitarService.GetAllProjects();
            }

            this.GuitarService.Create(Model);
            return RedirectToAction("Index");
        }

        public ActionResult GetGuitars(string sidx, string sord, int page, int rows)
        {

            if(!this.Request.IsAjaxRequest())
            {
                return HttpNotFound("ERROR! Porque estas intentando invocar ajax cuando el controlador al que llamas no tiene nada de Json?!!!");
            }

            var guitarras = this.GuitarService.GetGuitars();
            var result = new { items = new List<Object>() };

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = guitarras.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            IEnumerable<Guitars> prodPage;
            if (sidx == "Name") { 
                if (sord == "asc")
                    prodPage = guitarras.OrderBy(x => x.Name);
                else
                    prodPage = guitarras.OrderByDescending(x => x.Name);
            }
            else{
                if (sidx == "StarDate")
                {
                    if (sord == "asc")
                        prodPage = guitarras.OrderBy(x => x.StartDate);
                    else
                        prodPage = guitarras.OrderByDescending(x => x.StartDate);
                }
                else
                {
                    if (sidx == "PaintDate")
                    {
                        if (sord == "asc")
                            prodPage = guitarras.OrderBy(x => x.PaintDate);
                        else
                            prodPage = guitarras.OrderByDescending(x => x.PaintDate);
                    }
                    else
                    {
                        if (sidx == "TestDate")
                        {
                            if (sord == "asc")
                                prodPage = guitarras.OrderBy(x => x.TestDate);
                            else
                                prodPage = guitarras.OrderByDescending(x => x.TestDate);
                        }
                        else
                        {
                            if (sord == "asc")
                                prodPage = guitarras.OrderBy(x => x.FinishDate);
                            else
                                prodPage = guitarras.OrderByDescending(x => x.FinishDate);
                        }
                    }
                }
            }
            //prodPage = guitarras;

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (from p in prodPage
                        select new
                        {
                            id = p.Id,
                            cell = new string[] { p.Id.ToString(),
                                                  p.Name,
                                                  p.StartDate.ToShortDateString(),
                                                  p.PaintDate.ToShortDateString(),
                                                  p.TestDate.ToShortDateString(),
                                                  p.FinishDate.ToShortDateString()
                                                }
                        }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public void UpdateGuitar(Guitars model, FormCollection formcollection)
        {
            var guitar = this.GuitarService.GetOneGuitar(model.Id);

            guitar.Id = model.Id;
            guitar.StartDate = model.StartDate;
            guitar.PaintDate = model.PaintDate;
            guitar.TestDate = model.TestDate;
            guitar.FinishDate = model.FinishDate;

            try
            {
                var operation = formcollection["oper"];
                switch (operation)
                {
                    case "edit": this.GuitarService.Update(guitar); break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}