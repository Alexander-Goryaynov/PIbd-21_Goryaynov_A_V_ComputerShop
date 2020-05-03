using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class ImplementerBindingModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
