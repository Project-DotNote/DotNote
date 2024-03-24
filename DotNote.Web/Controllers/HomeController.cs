namespace DotNote.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using ViewModels;
    using ViewModels.Home;
    using Services.Data.Interfaces;
    
    public class HomeController : Controller
    { 
    private readonly INoteService noteService;
       
        public HomeController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel =
                await this.noteService.LastThreeNotesAsync();

            return View(viewModel);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}