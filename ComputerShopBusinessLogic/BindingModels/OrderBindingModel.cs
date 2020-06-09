using ComputerShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ComputerShopBusinessLogic.BindingModels
{
    [DataContract]
    public class OrderBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int? ClientId { get; set; }
        [DataMember]
        public int AssemblyId { get; set; }
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public OrderStatus Status { get; set; }
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DataMember]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public DateTime? DateFrom { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        public string ImplementerFIO { set; get; }
        public bool? AnyFreeOrders { get; set; }
        public bool? IsLackOfDetails { get; set; }
    }
}
