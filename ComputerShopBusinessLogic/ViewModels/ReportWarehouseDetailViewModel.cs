using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class ReportWarehouseDetailViewModel
    {
        public string WarehouseName { get; set; }
        public int TotalCount { get; set; }
        public List<(string, int)> Details { get; set; }
    }
}
