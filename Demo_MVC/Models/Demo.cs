using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_MVC.Models
{
    public class Demo
    {
        [Key]

       public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Username { get; set; }

        [Required]

        [DataType(DataType.Password)]
            
        public string Password { get; set; }    

        public string Role { get; set; }


   /*     public ICollection<Product> product { get; set; }*/
    }
}