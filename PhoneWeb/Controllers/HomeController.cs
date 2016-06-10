using PhoneWeb.Models;
using System.Linq;
using System.Web.Mvc;

namespace PhoneWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            Divisions _div = new Divisions();
            var subDiv = _div.GetSubdivisions();

            ViewBag.Divisions = subDiv;




            Employees _emps = new Employees();
            ViewBag.Title = "Телефоны ОГТ";

            return View(_emps);
        }

        //[ChildActionOnly]
        [HttpPost]
        public ActionResult EmloyeeSearch(string surname)
        {
            Employees _emps = new Employees();

            if (_emps.Count <= 0 || surname == null)
            {
                return HttpNotFound();
            }

            var temp = _emps.Where(emp => emp.Surname.ToLower().Contains(surname.ToLower())).ToList();

            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult EmloyeeFilterByDivision(string division)
        {
            Employees _emps = new Employees();

            if (_emps.Count <= 0 || division == null)
            {
                return HttpNotFound();
            }

            var temp = _emps.Where(emp => emp.Division.ToLower().Contains(division.ToLower())).ToList();

            return PartialView("EmloyeeSearch", temp);
        }
        [HttpPost]
        public ActionResult EmloyeeFilterByBureau(string bureau)
        {
            Employees _emps = new Employees();

            if (_emps.Count <= 0 || bureau == null)
            {
                return HttpNotFound();
            }

            var temp = _emps.Where(emp => emp.Bureau.ToLower().Contains(bureau.ToLower())).ToList();

            return PartialView("EmloyeeSearch", temp);
        }
    }
}