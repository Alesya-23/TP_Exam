using BusinessLogic.Atributs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPExamAuthumn.ViewModel
{
    public class ProductViewModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(visible: false)]
        public int DishId { get; set; }
        [Column(title: "Номер", width: 50)]
        public string name { get; set; }
        [Column(title: "Номер", width: 50)]
        public int count { get; set; }
        [Column(title: "Номер", width: 50)]
        public DateTime dateSupplier { get; set; }
        [Column(title: "Номер", width: 50)]
        public string placeMade { get; set; }
    }
}
