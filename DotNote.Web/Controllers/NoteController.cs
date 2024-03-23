using System.Security.Claims;

namespace DotNote.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Note;
    using Services.Data.Interfaces;
    using Services.Data.Models.Note;

    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            NoteFormModel formModel = new NoteFormModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NoteFormModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.noteService.CreateAsync(model, userId!);


            return this.RedirectToAction("All", "Note");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllNotesQueryModel queryModel)
        {
            AllNotesFilteredAndPagedServiceModel serviceModel = 
                await this.noteService.AllAsync(queryModel);

            queryModel.Notes = serviceModel.Notes;
            queryModel.TotalNotes = serviceModel.TotalNotesCount;
            
            return View(queryModel);
        }
    }
}
