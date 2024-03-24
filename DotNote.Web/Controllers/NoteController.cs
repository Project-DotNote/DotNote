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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool noteExists = await this.noteService
                .ExistsByIdAsync(id);
            if (!noteExists)
            {
                //this.TempData[ErrorMessage] = "Note with the provided id does not exist!";

                return this.RedirectToAction("All", "Note");
            }

            try
            {
                NoteDetailsViewModel viewModel = await this.noteService
                    .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                throw;
            };
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool noteExists = await this.noteService
                .ExistsByIdAsync(id);
            if (!noteExists)
            {
                //this.TempData[ErrorMessage] = "Note with the provided id does not exist!";

                return this.RedirectToAction("All", "Note");
            }

            try
            {
                NoteFormModel formModel = await this.noteService
                    .GetNoteForEditByIdAsync(id);


                return View(formModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, NoteFormModel model)
        {
            bool noteExists = await this.noteService
                .ExistsByIdAsync(id);
            if (!noteExists)
            {
                //this.TempData[ErrorMessage] = "Note with the provided id does not exist!";

                return this.RedirectToAction("All", "Note");
            }

            try
            {
                await this.noteService.EditNoteByIdAndFormModel(id, model);
            }
            catch (Exception)
            {
                throw;
            }

            return this.RedirectToAction("Details", "Note", new {id});
        }
    }
}
