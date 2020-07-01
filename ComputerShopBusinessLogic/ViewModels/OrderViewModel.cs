using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using ComputerShopBusinessLogic.Enums;
using System.Runtime.Serialization;
using ComputerShopBusinessLogic.Attributes;

namespace ComputerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {        
        [DataMember]
        public int AssemblyId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        [DisplayName("Сборка")]
        [Column(title: "Сборка", gridViewAutoSize: GridViewAutoSize.DisplayedCells)]
        public string AssemblyName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [DisplayName("ФИО Клиента")]
        [Column(title: "ФИО Клиента", width: 150)]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [DisplayName("Исполнитель")]
        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerFIO { get; set; }
        public override List<string> Properties() => new List<string> { "Id",
            "ClientFIO", "AssemblyName", "ImplementerFIO", "Count", "Sum", "Status", "DateCreate", "DateImplement" };
    }
}
