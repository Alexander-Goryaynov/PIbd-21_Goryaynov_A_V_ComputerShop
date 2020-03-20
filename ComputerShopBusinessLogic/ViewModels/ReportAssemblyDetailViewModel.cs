using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class ReportAssemblyDetailViewModel
    {        
        public string DetailName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Assemblies { get; set; }        
    }
}
