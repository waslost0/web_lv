using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Translator.Models;

namespace Translator.Controllers
{
    public class TranslatorController : Controller
    {
        // GET: 
        public IActionResult Index()
        {
            return View();
        }

        // GET: 
        public IActionResult Translate(string id)
        {
            Models.Translator dict = new Models.Translator("dict.txt");
            string translation = dict.Transalte(id);
            var translaedWord = new TranslateViewModel() { WordToTranslate = id, TranslatedWord = translation };

            if (String.IsNullOrEmpty(translation))
            {
                return new NotFoundObjectResult(new { error = "Word not found", id }) { StatusCode = 404 };
            }

            //return Content(translation);
            return View(translaedWord);
        }

        // GET: 
        [HttpPost]
        public IActionResult Search(TranslateViewModel model)
        {
            Models.Translator dict = new Models.Translator("dict.txt");
            string translation = dict.Transalte(model.WordToTranslate.ToLower());
            var translaedWord = new TranslateViewModel() { WordToTranslate = model.WordToTranslate, TranslatedWord = translation };

            if (String.IsNullOrEmpty(translation))
            {
                return new NotFoundObjectResult(new { error = "Word not found", model.WordToTranslate }) { StatusCode = 404 };
            }

            //return Content(translation);
            return View("Translate", translaedWord);
        }
    }
}
