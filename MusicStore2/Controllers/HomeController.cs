using MusicStore2.DataBaseManager;
using MusicStore2.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicStore2.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeSweetHome
        //public ActionResult Index(int page = 1)
        //{
        //    var result = InstrumentManager.GetInstruments();
        //    int pageSize = 3; //количество объектов на странице
        //    var result2 = result.Skip((page - 1) * pageSize).Take(pageSize);
        //    PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = result.Count };
        //    IndexViewModel indexViewModel = new IndexViewModel { PageInfo = pageInfo, Instruments = result2 };
        //    if (page > indexViewModel.PageInfo.TotalPages)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return View(indexViewModel);
        //    }
        //}
        //public async Task<ActionResult> Index(int page = 1)
        //{
        //    var result = await InstrumentManager.GetInstrumentsAsync();
        //    if( result != null)
        //    {
        //        int pageSize = 3; //количество объектов на странице
        //        var result2 = result.Skip((page - 1) * pageSize).Take(pageSize);
        //        PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = result.Count };
        //        IndexViewModel indexViewModel = new IndexViewModel { PageInfo = pageInfo, Instruments = result2 };
        //        if (page > indexViewModel.PageInfo.TotalPages)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return View(indexViewModel);
        //        }
        //    }
        //    else
        //    {
        //        return View("~/Home/HelloAdmin");
        //    }
            
        //}
        public async Task<ActionResult> Index(int? page)
        {
            var  result = await InstrumentManager.GetInstrumentsAsync();
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));
        }     
    }
}