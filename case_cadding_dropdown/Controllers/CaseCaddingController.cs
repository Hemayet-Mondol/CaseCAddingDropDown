using case_cadding_dropdown.Data;
using Microsoft.AspNetCore.Mvc;

namespace case_cadding_dropdown.Controllers
{
    public class CaseCaddingController : Controller
    {
        private readonly CaseCaddingDbContext _context;
        public CaseCaddingController(CaseCaddingDbContext context)
        {
            _context = context;
        }
        public JsonResult Country()
        {
            var ctn = _context.CountryTable.ToList();
            return new JsonResult(ctn);
        }

        public JsonResult State(int id)
        {
            var st = _context.StateTable.Where(st => st.Country.Id == id).ToList();
            return new JsonResult(st);
        }
        public JsonResult City(int id)
        {
            var city = _context.CityTable.Where(c => c.State.Id == id).ToList();
            return new JsonResult(city);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CaseCaddingDropDown()
        {
            return View();
        }
    }
}
