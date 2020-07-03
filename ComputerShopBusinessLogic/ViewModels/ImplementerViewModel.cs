using ComputerShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ComputerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ImplementerViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }
        [DataMember]
        [Column(title: "Время на работу", width: 100)]
        public int WorkingTime { get; set; }
        [DataMember]
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }
        public override List<string> Properties() => new List<string> { 
            "Id", "FIO", "WorkingTime", "PauseTime" };
    }
}
