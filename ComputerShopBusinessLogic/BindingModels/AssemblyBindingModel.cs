using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class AssemblyBindingModel
    {
        public int? Id { get; set; }
        public string AssemblyName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> AssemblyDetails { get; set; }
    }
}
