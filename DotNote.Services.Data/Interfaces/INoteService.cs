namespace DotNote.Services.Data.Interfaces
{
    using Models.Note;
    using Web.ViewModels.Note;
    public interface INoteService
    {
        Task<AllNotesFilteredAndPagedServiceModel> AllAsync(AllNotesQueryModel queryModel);
    }
}
