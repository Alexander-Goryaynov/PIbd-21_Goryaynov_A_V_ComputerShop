using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerShopDatabaseImplement.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual List<WarehouseDetail> WarehouseDetails { get; set; }
    }
}
