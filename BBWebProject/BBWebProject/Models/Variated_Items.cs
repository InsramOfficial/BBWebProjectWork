﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBWebProject.Models
{
    public class Variated_Items
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Enter Description")]
        public string Description { get; set; }
        public string Image { get; set; }
        public string Regular { get; set; }
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
