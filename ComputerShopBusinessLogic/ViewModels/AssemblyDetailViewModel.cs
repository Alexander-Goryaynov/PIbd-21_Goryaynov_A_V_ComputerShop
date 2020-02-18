using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class AssemblyDetailViewModel
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int DetailId { get; set; }
        [DisplayName("Деталь")]
        public string DetailName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
