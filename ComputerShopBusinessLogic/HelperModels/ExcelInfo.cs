using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportAssemblyDetailViewModel> AssemblyDetails { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
        public List<ReportWarehouseDetailViewModel> WarehouseDetails { get; set; }
    }
}
