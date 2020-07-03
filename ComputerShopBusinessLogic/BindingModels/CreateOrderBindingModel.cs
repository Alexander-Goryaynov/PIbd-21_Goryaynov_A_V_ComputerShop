using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        public int AssemblyId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
