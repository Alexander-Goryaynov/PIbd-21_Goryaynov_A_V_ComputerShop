using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название детали")]
        public string DetailName { get; set; }
    }
}
