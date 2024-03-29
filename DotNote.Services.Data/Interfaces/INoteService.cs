﻿namespace DotNote.Services.Data.Interfaces
{
    using Models.Note;
    using Web.ViewModels.Note;
    using Web.ViewModels.Home;

    public interface INoteService
    {
        Task<AllNotesFilteredAndPagedServiceModel> AllAsync(AllNotesQueryModel queryModel);
        Task CreateAsync(NoteFormModel formModel, string userId);
        Task<IEnumerable<IndexViewModel>> LastThreeNotesAsync();
        Task<NoteDetailsViewModel> GetDetailsByIdAsync(string noteId);
        Task<bool> ExistsByIdAsync(string noteId);
        Task<NoteFormModel> GetNoteForEditByIdAsync(string noteId);
        Task EditNoteByIdAndFormModel(string noteId, NoteFormModel formModel);
        Task<NotePreDeleteDetailsViewModel> GetNoteForDeleteByIdAsync(string noteId);
        Task DeleteNoteByIdAsync(string noteId);
    }
}
