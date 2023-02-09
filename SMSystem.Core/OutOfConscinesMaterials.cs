using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMSystem.Core
{
   public class OutOfConscinesMaterials
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Store { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public string Supplier { get; set; }
        [Required]
        public string ReciptNo { get; set; }
        [Required]
        public string RectipName { get; set; }
        [Required]
        public DateTime RectipDate { get; set; }
        [Required]
        public int InterNo { get; set; }
        public byte[] RectipImg { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        public DateTime ExpDate { get; set; }
        public string State { get; set; }
        [Required]
        public string User { get; set; }
    }
}
