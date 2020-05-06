using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<AssemblyViewModel> Assemblies{ get; set; }
        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
