namespace DotNote.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Models.Note;
    using Web.ViewModels.Note;
    using DotNote.Data;
    using DotNote.Data.Models;
    using DotNote.Web.ViewModels.Enums;

    public class NoteService : INoteService
    {
        private readonly DotNoteDbContext dbContext;
        public NoteService(DotNoteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AllNotesFilteredAndPagedServiceModel> AllAsync(AllNotesQueryModel queryModel)
        {
            IQueryable<Note> notesQuery = this.dbContext
                .Notes
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                notesQuery = notesQuery
                    .Where(n => EF.Functions.Like(n.Title, wildCard) ||
                                EF.Functions.Like(n.Subtitle, wildCard) ||
                                EF.Functions.Like(n.Title, wildCard));
            }

            notesQuery = queryModel.NoteSorting switch
            {
                NoteSorting.Newest => notesQuery
                    .OrderByDescending(n => n.CreatedAt),
                NoteSorting.Oldest => notesQuery
                    .OrderBy(n => n.CreatedAt),
                NoteSorting.AlphabeticalAscending => notesQuery
                    .OrderBy(n => n.Title),
                NoteSorting.AlphabeticalDescending => notesQuery
                    .OrderByDescending(n => n.Title)
            };

            IEnumerable<NoteAllViewModel> allNotes = await notesQuery
                .Where(n => n.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.NotesPerPage)
                .Take(queryModel.NotesPerPage)
                .Select(n => new NoteAllViewModel
                {
                    Id = n.Id.ToString(),
                    Title = n.Title,
                    Subtitle = n.Subtitle,
                    Text = n.Text,
                    //CreatedAt = n.CreatedAt.ToString("ddMMyyyy")
                })
                .ToArrayAsync();
            int totalNotes = notesQuery.Count();

            return new AllNotesFilteredAndPagedServiceModel()
            {
                TotalNotesCount = totalNotes,
                Notes = allNotes
            };
        }
    }
}
