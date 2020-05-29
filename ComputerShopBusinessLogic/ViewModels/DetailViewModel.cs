using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using ComputerShopBusinessLogic.Attributes;

namespace ComputerShopBusinessLogic.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {        
        [Column(title: "Название детали", gridViewAutoSize: GridViewAutoSize.Fill)]        
        public string DetailName { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "DetailName" };
    }
}
