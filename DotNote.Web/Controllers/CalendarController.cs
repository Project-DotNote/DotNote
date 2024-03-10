using Microsoft.AspNetCore.Mvc;

namespace DotNote.Web.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
