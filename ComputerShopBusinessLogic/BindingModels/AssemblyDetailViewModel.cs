using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ComputerShopBusinessLogic.BindingModels
{
    [DataContract]
    public class AssemblyDetailViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int AssemblyId { get; set; }
        [DataMember]
        public int DetailId { get; set; }
        [DataMember]
        [DisplayName("Деталь")]
        public string DetailName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
