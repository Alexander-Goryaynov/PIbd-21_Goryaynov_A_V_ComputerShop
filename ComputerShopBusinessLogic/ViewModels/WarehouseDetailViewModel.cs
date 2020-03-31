using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class WarehouseDetailViewModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int DetailId { get; set; }
        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
        [DisplayName("Название детали")]
        public string DetailName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
