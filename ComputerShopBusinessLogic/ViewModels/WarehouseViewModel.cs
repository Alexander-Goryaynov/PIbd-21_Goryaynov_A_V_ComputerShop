using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ComputerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class WarehouseViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название склада")]
        public string Name { get; set; }
        [DataMember]
        public List<WarehouseDetailViewModel> WarehouseDetails { get; set; }
    }
}
