using ComputerShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerShopDatabaseImplement.Models
{
    public class Assembly
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("AssemblyId")]
        public virtual List<AssemblyDetail> AssemblyDetails { get; set; }
        [ForeignKey("OrderId")]
        public virtual List<Order> Order { get; set; }
    }
}
