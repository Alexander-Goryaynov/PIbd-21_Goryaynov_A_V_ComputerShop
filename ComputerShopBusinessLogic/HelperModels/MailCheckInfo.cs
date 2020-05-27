using ComputerShopBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }
        public int PopPort { get; set; }
        public IMessageInfoLogic Logic { get; set; }
    }
}
