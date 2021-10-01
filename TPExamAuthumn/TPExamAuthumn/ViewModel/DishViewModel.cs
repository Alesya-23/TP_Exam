using BusinessLogic.Atributs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPExamAuthumn.ViewModel
{
    public class DishViewModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "Номер", width: 50)]
        public string name { get; set; }
        [Column(title: "Номер", width: 50)]
        public string type { get; set; }

        [Column(title: "Номер", width: 50)]
        public DateTime datePrepare { get; set; }
        [Column(visible: false)]
        public virtual Dictionary<int, (string, string, DateTime)>  Products { get; set; }
    }
}
