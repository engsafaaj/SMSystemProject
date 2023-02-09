using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMSystem.Core
{
   public class OutComeMaterail
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string MaterialName { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double TotalPrice { get; set; }

        // Navigation
        public int MaterialId { get; set; }
        public OutCome outCome { get; set; }
    }
}
