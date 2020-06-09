using ComputerShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int ClientId { set; get; }
        [Required]
        public string ClientFIO { set; get; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public int AssemblyId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Assembly Assembly { get; set; }
        public int? ImplementerId { get; set; }
        public Implementer Implementer { get; set; }
        public string ImplementerFIO { get; set; }
    }
}
