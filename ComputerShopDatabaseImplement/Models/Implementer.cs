using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
        public List<Order> Orders { get; set; }
    }
}
