using System.Collections.Generic;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseDetailBindingModel> WarehouseDetails { get; set; }
    }
}
