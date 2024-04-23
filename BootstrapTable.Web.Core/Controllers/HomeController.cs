using BootstrapTable.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace BootstrapTable.Web.Core.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() { return View(); }
        public ActionResult Basic() { return View(); }
        public ActionResult Paged() { return View(); }
        public ActionResult Menus() { return View(); }
        public ActionResult Links() { return View(); }
        public ActionResult Sorting() { return View(); }
        public ActionResult TableStyles() { return View(); }
        public ActionResult ColumnStyles() { return View(); }
        public ActionResult Toolbar() { return View(); }
        public ActionResult Search() { return View(); }
        public ActionResult Extensions() { return View(); }
        public ActionResult Checkboxes() { return View(); }

        private List<Person> PeopleSource()
        {
            return new List<Person>
            {
                new Person { Id = 1, FirstName = "Odysseus", LastName = "Kirkland", Email = "fermentum@Proinvelnisl.net", BirthDate = DateTime.Parse("25/06/2000"), Location = "Eritrea", },
                new Person { Id = 2, FirstName = "Jocelyn", LastName = "Mccall", Email = "Nullam.lobortis@Fuscefermentum.ca", BirthDate = DateTime.Parse("05/09/1949"), Location = "Bolivia", },
                new Person { Id = 3, FirstName = "Lael", LastName = "Trujillo", Email = "enim.Suspendisse.aliquet@nec.com", BirthDate = DateTime.Parse("04/09/1991"), Location = "Sri Lanka", },
                new Person { Id = 4, FirstName = "Chelsea", LastName = "Mcgee", Email = "magna.et@dolornonummyac.co.uk", BirthDate = DateTime.Parse("21/07/1960"), Location = "Hungary", },
                new Person { Id = 5, FirstName = "Connor", LastName = "Pope", Email = "In.tincidunt@eu.com", BirthDate = DateTime.Parse("23/07/1987"), Location = "Albania", },
                new Person { Id = 6, FirstName = "Dustin", LastName = "Arnold", Email = "ante.Nunc@Pellentesquetincidunttempus.com", BirthDate = DateTime.Parse("15/04/1946"), Location = "Lithuania", },
                new Person { Id = 7, FirstName = "Tatum", LastName = "Dale", Email = "turpis.egestas.Aliquam@atauctor.edu", BirthDate = DateTime.Parse("15/05/1981"), Location = "South Africa", },
                new Person { Id = 8, FirstName = "Priscilla", LastName = "Roach", Email = "at.fringilla@risus.com", BirthDate = DateTime.Parse("20/05/1984"), Location = "Lebanon", },
                new Person { Id = 9, FirstName = "Cade", LastName = "Smith", Email = "auctor.velit.eget@egetvolutpat.edu", BirthDate = DateTime.Parse("19/03/1978"), Location = "New Zealand", },
                new Person { Id = 10, FirstName = "James", LastName = "Frank", Email = "purus.Nullam@iderat.co.uk", BirthDate = DateTime.Parse("01/07/1954"), Location = "Norfolk Island", },
            };
        }

        public JsonResult GetPeopleData()
        {
            System.Threading.Thread.Sleep(1000);
            return Json(PeopleSource());
        }

        public JsonResult GetPeoplePaged(int offset, int limit, string search, string sort, string order)
        {
            var people = PeopleSource();
            var model = new
            {
                total = people.Count(),
                rows = people.Skip((offset / limit) * limit).Take(limit),
            };
            return Json(model);
        }

        public JsonResult GetPeopleSearch(int offset, int limit, string search, string sort, string order)
        {
            var people = PeopleSource().AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(search), o =>
                    o.Email.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                    o.FirstName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                    o.LastName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                    o.Location.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(sort ?? "LastName", order)
                .ToList();

            var model = new
            {
                total = people.Count(),
                rows = people.Skip((offset / limit) * limit).Take(limit),
            };
            return Json(model);
        }

        public ActionResult MenuAction(int id)
        {
            return View("MenuAction", id);
        }

        public ActionResult TableAction(int[] ids)
        {
            if (ids != null)
                return Json(new { result = string.Join(", ", ids) });
            else
                return Json(new { result = "Nothing selected!" });
        }
    }
}
