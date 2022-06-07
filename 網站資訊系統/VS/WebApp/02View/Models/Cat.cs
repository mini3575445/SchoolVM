using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace _02View.Models
{
    public class Cat
    {
        [DisplayName("編號")]
        [Required]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Color { get; set; }
    }
}