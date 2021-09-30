using System;
using System.Collections.Generic;
using System.Text;

namespace TPExamAuthumn.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public DateTime dateSupplier { get; set; }
        public string placeMade { get; set; }
    }
}
