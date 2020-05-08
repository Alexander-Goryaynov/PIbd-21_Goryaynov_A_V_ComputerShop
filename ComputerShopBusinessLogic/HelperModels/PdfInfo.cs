using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportAssemblyDetailViewModel> AssemblyDetails { get; set; }
        public List<ReportWarehouseDetailViewModel> WarehouseDetail { get; set; }
    }
}
