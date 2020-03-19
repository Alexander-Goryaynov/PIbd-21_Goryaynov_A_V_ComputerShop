using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopFileImplement.Models
{
    public class WarehouseDetail
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int DetailId { get; set; }
        public int Count { get; set; }
    }
}
