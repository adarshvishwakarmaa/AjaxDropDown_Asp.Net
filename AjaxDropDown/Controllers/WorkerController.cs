using AjaxDropDown.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace AjaxDropDown.Controllers
{
    public class WorkerController : Controller
    {
        private readonly DropdownContext context;
        public WorkerController(DropdownContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var worker = context.Workers.ToList();
            return View(worker);
        }

        public IActionResult Create()
        {
           List<State>states = context.States.ToList();
            ViewBag.States = states;
            return View();
        }

        public JsonResult GetDistrict(int id)
        {
            var dist = context.Districts.Where(x=>x.StateId==id);
            return Json(dist);
        }
    }
}
