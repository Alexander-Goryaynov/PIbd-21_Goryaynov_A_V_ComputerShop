using ComputerShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ComputerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }
        [DataMember]
        [DisplayName("E-mail")]
        [Column(title: "E-mail", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        [DataMember]
        public string Password { get; set; }
        public override List<string> Properties() => new List<string> {"Id", "FIO", "Email" };
    }
}
