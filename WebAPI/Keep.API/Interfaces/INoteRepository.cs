using Keep.API.Models.Entities;

namespace Keep.API.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllNotes();
        Task<Note> GetNoteById(Guid id);
    }
}
