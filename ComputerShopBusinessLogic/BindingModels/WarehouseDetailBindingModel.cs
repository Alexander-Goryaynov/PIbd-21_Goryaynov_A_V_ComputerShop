using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class WarehouseDetailBindingModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int DetailId { get; set; }
        public int Count { get; set; }
    }
}
