using Keep.API.Data;
using Keep.API.Interfaces;
using Keep.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keep.API.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly KeepDbContext _context;

        public NoteRepository(KeepDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetNoteById(Guid id)
        {
            return await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
