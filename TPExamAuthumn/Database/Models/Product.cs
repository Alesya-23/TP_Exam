using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public int DishId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int count { get; set; }
        [Required]
        public DateTime dateSupplier { get; set; }
        [Required]
        public string placeMade { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
