using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string Name { get; set; }
        public List<WarehouseDetailViewModel> WarehouseDetails { get; set; }
    }
}
