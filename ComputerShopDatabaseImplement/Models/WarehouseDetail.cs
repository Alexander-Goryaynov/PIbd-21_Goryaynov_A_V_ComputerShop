using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerShopDatabaseImplement.Models
{
    public class WarehouseDetail
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int DetailId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
