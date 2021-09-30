using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime datePrepare { get; set; }

        [ForeignKey("DishId")]
        public virtual List<Product> Products { get; set; }
    }
}
