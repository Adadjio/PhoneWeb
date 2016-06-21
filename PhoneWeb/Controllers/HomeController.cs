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

            Employees _emps = new DataLayer().GetEmployees();
            ViewBag.Title = "Телефоны ОГТ";

            ViewBag.TxtUnderHeader = "Все телефоны";
            
            return View(_emps);
        }

        
        [HttpPost]
        public ActionResult EmloyeeSearch(string surname)
        {
            Employees _emps = new DataLayer().GetEmployees();

            if (_emps.Count <= 0 || surname == null)
            {
                return HttpNotFound();
            }

            ViewBag.TxtUnderHeader = "Все телефоны";

            var temp = _emps.Where(emp => emp.Surname.ToLower().Contains(surname.Trim().ToLower())).ToList();

            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult EmloyeeFilterByDivision(string division)
        {
            Employees _emps = new DataLayer().GetEmployees();

            if (_emps.Count <= 0 || division == null)
            {
                return HttpNotFound();
            }
            if (division == "ТО ПВ И ЭО") division = "ПВ и ЭО";
            else if (division == "ТО ПМ И ШПО") division = "ПМиШПО";

            var temp = _emps.Where(emp => emp.Division.ToLower().Contains(division.ToLower())).ToList();
            ViewBag.TxtUnderHeader = division;
            return PartialView("EmloyeeSearch", temp);
        }
        [HttpPost]
        public ActionResult EmloyeeFilterByBureau(string bureau)
        {
            Employees _emps = new DataLayer().GetEmployees();

            if (_emps.Count <= 0 || bureau == null)
            {
                return HttpNotFound();
            }

            if (bureau == "БПО №1") bureau = "БПО№1";
            else if (bureau == "БПО №2") bureau = "БПО№2";

            var temp = _emps.Where(emp => emp.Bureau.ToLower().Contains(bureau.ToLower())).ToList();
            ViewBag.TxtUnderHeader = bureau;
            return PartialView("EmloyeeSearch", temp);
        }
    }
}