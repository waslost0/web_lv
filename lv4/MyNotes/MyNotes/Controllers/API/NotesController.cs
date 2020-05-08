using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Models;

namespace MyNotes.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public NotesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/notes
        [Route("/api/notes/list")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var notes = _db.Notes.ToList();
            return new OkObjectResult(notes);
        }

        // GET api/movies/1
        [HttpGet("{id}")]
        public IActionResult GetNote(int id)
        {
            var note = _db.Notes.SingleOrDefault(n => n.Id == id);
            if (note == null)
                return new NotFoundObjectResult(new { error = "Note not found.", id });

            return new OkObjectResult(note);
        }


        // DELETE: api/notes/delete/{id}
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var noteInDb = _db.Notes.SingleOrDefault(c => c.Id == id);

            if (noteInDb == null)
            {
                return new NotFoundObjectResult(new { success = false, message = "Note not found.", id });
            }

            _db.Notes.Remove(noteInDb);
            _db.SaveChanges();

            return new OkObjectResult(new { success = true, id, message = "Note deleted." }) { StatusCode = 201 };
        }

        // DELETE: api/note/add
        [HttpPost("add")]
        [Route("/api/note/add")]
        public IActionResult AddNote(Note note)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            _db.Notes.Add(note);
            _db.SaveChanges();

            return new OkObjectResult(note);
        }
    }
}
