using System;
using System.Collections.Generic;
using System.Text;

namespace TPExamAuthumn.ViewModel
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime datePrepare { get; set; }
        public virtual Dictionary<int, (string, string, DateTime)>  Products { get; set; }
    }
}
