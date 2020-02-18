using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
