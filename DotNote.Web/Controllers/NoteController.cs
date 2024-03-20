using DotNote.Services.Data.Interfaces;
using DotNote.Services.Data.Models.Note;
using DotNote.Web.ViewModels.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNote.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [AllowAnonymous]
        public IActionResult New()
        {
            return View();
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
