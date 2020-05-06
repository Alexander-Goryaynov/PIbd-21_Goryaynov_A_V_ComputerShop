using ComputerShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerShopDatabaseImplement.Models
{
    public class AssemblyDetail
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int DetailId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Assembly Assembly { get; set; }
    }
}
