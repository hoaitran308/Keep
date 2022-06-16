using Keep.API.Models.DTO;
using Keep.API.Models.Entities;

namespace Keep.API.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllNotes();
        Task<Note> GetNoteById(Guid id);
        Task<Note> AddNote(AddNoteRequest addNoteRequest);
        Task<Note> UpdateNote(UpdateNoteRequest updateNoteRequest, Guid noteId);
        Task<bool> IsExistNote(Guid id);
    }
}
