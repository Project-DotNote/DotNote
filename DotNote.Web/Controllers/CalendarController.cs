namespace DotNote.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CalendarController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
