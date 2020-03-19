using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int AssemblyId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
