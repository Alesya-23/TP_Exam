using System;
using System.Collections.Generic;
using System.Text;

namespace TPExamAuthumn.BindingModels
{
    public class ReportDishesBindingModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string productName { get; set; }
        public DateTime datePrepare { get; set; }
        public DateTime dateSupplier { get; set; }
        public string placeMade { get; set; }
    }
}
