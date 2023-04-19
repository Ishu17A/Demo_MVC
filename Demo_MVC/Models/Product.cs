using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_MVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get ; set; }

        [Required]
        public string Description { get; set; }

        public Guid PostedBy { get; set; } 


        public Guid Guid { get; set; }


    }
}