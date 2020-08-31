using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using ComputerShopBusinessLogic.Attributes;

namespace ComputerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class AssemblyViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Сборка", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AssemblyName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> AssemblyDetails { get; set; }
        public override List<string> Properties() => new List<string> {
            "Id", "AssemblyName", "Price" };
    }
}
