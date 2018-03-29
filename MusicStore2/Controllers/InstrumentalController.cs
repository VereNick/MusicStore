using MusicStore2.DataBaseManager;
using MusicStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicStore2.Controllers
{
    public class InstrumentalController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {  
                return View();
           
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Instrument instrument)
        {
            InstrumentManager.AddInstrument(instrument);
            var results = InstrumentManager.GetInstruments();
            return View("../Instrumental/AddResult");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [HandleError(ExceptionType = typeof(ArgumentNullException))]
        public ActionResult Delete(Guid id)
        {
            var Oneinstrument = InstrumentManager.Get(id);
            if(Oneinstrument !=null)
            {
                return View(Oneinstrument);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            } 
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
                var Oneinstrument = InstrumentManager.Get(id);
                if (Oneinstrument == null)
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    InstrumentManager.DeleteIntrument(id);
                    var list = InstrumentManager.GetInstruments();
                    return View("../Home/Index", list);
                }
        }
        //[HttpGet]
        //public ActionResult Details(Guid id)
        //{
        //    var result = InstrumentManager.Get(id);
        //    if (result == null)
        //    {
        //        return RedirectToRoute(new { controller = "Home", action = "Index" });
        //    }
        //    else
        //    {
        //        return View("../Instrumental/Details", result);
        //    }
        //}
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await InstrumentManager.GetAsync(id);
            if (result == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                return View("../Instrumental/Details", result);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var result =  await InstrumentManager.GetAsync(id);
            if (result == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(result);
            }
        }
        //public ActionResult Edit(Guid id)
        //{
        //    var result = InstrumentManager.Get(id);
        //    if (result == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return View(result);
        //    }
        //}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Instrument inst)
        {
            InstrumentManager.EditInstrument(inst);
            //var result = InstrumentManager.GetInstruments();
            return RedirectToAction("../Home/Index");
        }


    }
}