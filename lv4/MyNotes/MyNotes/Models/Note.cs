using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Models
{
    public class Note
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
