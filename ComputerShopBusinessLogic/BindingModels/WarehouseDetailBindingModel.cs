using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{   
    [DataContract]
    public class WarehouseDetailBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int WarehouseId { get; set; }
        [DataMember]
        public int DetailId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
