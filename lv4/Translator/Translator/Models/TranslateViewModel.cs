using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Models
{
    public class TranslateViewModel
    {
        public string TranslatedWord { get; set; }
        [Required]
        public string WordToTranslate { get; set; }

    }
}
