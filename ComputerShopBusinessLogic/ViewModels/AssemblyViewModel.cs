using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class AssemblyViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название сборки")]
        public string AssemblyName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public List<AssemblyDetailViewModel> AssemblyDetails { get; set; }
    }
}
