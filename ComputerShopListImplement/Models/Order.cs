using ComputerShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopListImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public int ClientId { set; get; }
        public string ClientFIO { set; get; }
        public int ImplementerId { get; set; }
    }
}
