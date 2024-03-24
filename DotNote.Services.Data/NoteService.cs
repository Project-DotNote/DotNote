namespace DotNote.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Models.Note;
    using Web.ViewModels.Note;
    using Web.ViewModels.Home;
    using Web.ViewModels.Enums;
    using DotNote.Data;
    using DotNote.Data.Models;

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
                                    EF.Functions.Like(n.Text, wildCard));
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
                    .OrderByDescending(n => n.Title),
                _ => notesQuery
                    .OrderByDescending(n => n.CreatedAt)
                    .ThenBy(n => n.Title)
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
                    IsActive = n.IsActive
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

        public async Task CreateAsync(NoteFormModel formModel, string userId)
        {
            Note newNote = new Note()
            {
                Title = formModel.Title,
                Subtitle = formModel.Subtitle,
                Text = formModel.Text,
                CreatedAt = DateTime.UtcNow,
                UserId = Guid.Parse(userId),
                IsActive = true
            };

            await this.dbContext.Notes.AddAsync(newNote);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeNotesAsync()
        {
            IEnumerable<IndexViewModel> lastThreeNotes = await this.dbContext
                .Notes
                .OrderByDescending(n => n.CreatedAt)
                .ThenBy(n => n.Title)
                .Take(3)
                .Select(n => new IndexViewModel()
                {
                    Id = n.Id.ToString(),
                    Title = n.Title,
                    Subtitle = n.Subtitle,
                    Text = n.Text
                })
                .ToArrayAsync();

            return lastThreeNotes;
        }

        public async Task<NoteDetailsViewModel> GetDetailsByIdAsync(string noteId)
        {
            Note note = await this.dbContext
                .Notes
                .Include(n => n.User)
                .Where(n => n.IsActive)
                .FirstAsync(n => n.Id.ToString() == noteId);

            return new NoteDetailsViewModel()
            {
                Id = note.Id.ToString(),
                Title = note.Title,
                Subtitle = note.Subtitle,
                Text = note.Text,
                IsActive = note.IsActive,
                CreatedAt = note.CreatedAt.ToString()
            };

        }

        public async Task<bool> ExistsByIdAsync(string noteId)
        {
            bool result = await this.dbContext
                .Notes
                .Where(n => n.IsActive)
                .AnyAsync(n => n.Id.ToString() == noteId);

            return result;
        }
    }
}
