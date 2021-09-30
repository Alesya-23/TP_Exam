using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace BusinessLogic.ViewModels
{
    [DataContract]
    public class ReportDishesViewModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string productName { get; set; }
        [DataMember]
        public DateTime datePrepare { get; set; }
        [JsonIgnore]
        public string placeMade { get; set; }
        [DataMember]
        public DateTime dateSupplier { get; set; }
    }
}
