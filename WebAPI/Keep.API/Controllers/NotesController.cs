using Keep.API.Interfaces;
using Keep.API.Models.DTO;
using Keep.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Keep.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Note>))]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _noteRepository.GetAllNotes();
            return Ok(notes);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetNoteById")]
        [ProducesResponseType(200, Type = typeof(Note))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetNoteById(Guid id)
        {
            var note = await _noteRepository.GetNoteById(id);

            if (note is null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Note))]
        public async Task<IActionResult> AddNote(AddNoteRequest addNoteRequest)
        {
            var note = await _noteRepository.AddNote(addNoteRequest);

            return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        }
    }
}
