using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopFileImplement.Models
{
    public class AssemblyDetail
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int DetailId { get; set; }
        public int Count { get; set; }
    }
}
