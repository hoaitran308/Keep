using Keep.API.Data;
using Keep.API.Interfaces;
using Keep.API.Models.DTO;
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

        public async Task<Note> AddNote(AddNoteRequest addNoteRequest)
        {
            var note = new Note()
            {
                Id = Guid.NewGuid(),
                Title = addNoteRequest.Title,
                Content = addNoteRequest.Content,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            return note;
        }

        public async Task<Note> UpdateNote(UpdateNoteRequest updateNoteRequest, Guid noteId)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(note => note.Id == noteId);

            note.Title = updateNoteRequest.Title;
            note.Content = updateNoteRequest.Content;
            note.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return note;
        }

        public async Task<bool> IsExistNote(Guid id)
        {
            return await _context.Notes.AnyAsync(x => x.Id == id);
        }
    }
}
