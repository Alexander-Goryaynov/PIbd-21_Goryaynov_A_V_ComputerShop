using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseDetailBindingModel> WarehouseDetails { get; set; }
    }
}
