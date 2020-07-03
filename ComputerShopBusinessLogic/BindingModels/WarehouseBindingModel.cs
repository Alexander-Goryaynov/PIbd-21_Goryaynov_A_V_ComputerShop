using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ComputerShopBusinessLogic.BindingModels
{
    [DataContract]
    public class WarehouseBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string WarehouseName { get; set; }
        [DataMember]
        public List<WarehouseDetailBindingModel> WarehouseDetails { get; set; }
    }
}
