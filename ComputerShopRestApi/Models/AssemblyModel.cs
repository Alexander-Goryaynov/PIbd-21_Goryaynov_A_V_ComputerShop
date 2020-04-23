using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShopRestApi.Models
{
    public class AssemblyModel
    {
        public int Id { get; set; }
        public string AssemblyName { get; set; }
        public decimal Price { get; set; }
    }
}
