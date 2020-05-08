using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Models;

namespace MyNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NotesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Notes

        
        public IActionResult Index()
        {
            var notes = _db.Notes.ToList();
            if (notes == null)
                return NotFound();

            return View(notes);
        }

        public IActionResult List()
        {
            var notes = _db.Notes.ToList();
            return new OkObjectResult(new { notes }) { StatusCode = 201 };
        }

        [Route("/note/add")]
        public IActionResult New()
        {
            var note = new Note { };
            
            return View("NotesForm", note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Note note)
        {

            if (!ModelState.IsValid)
            {
   
                return View("NotesForm", note);
            }


            if (note.Id == 0)
            {
                _db.Notes.Add(note);
            }
            else
            {
                _db.Notes.Update(note);
            }

            _db.SaveChanges();
            return RedirectToAction("List", "Notes");
        }



        // GET: Notes/Edit/5
        public IActionResult Edit(int id)
        {
            var note = _db.Notes.SingleOrDefault(m => m.Id == id);
            if (note == null)
                return NotFound();

            return View("NotesForm", note);
        }
    }
}