using System;
using System.Collections.Generic;
using System.Text;

namespace TPExamAuthumn.BindingModel
{
    public class DishBindingModel
    {
        public int? Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime datePrepare { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public virtual Dictionary<int, (string, string, DateTime)> Products { get; set; }
    }
}
