using Microsoft.AspNetCore.Mvc;

namespace DotNote.Web.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
