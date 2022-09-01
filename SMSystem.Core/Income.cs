using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMSystem.Core
{
    public class Income
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
        public byte[] RectipImg { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        public DateTime ExpDate { get; set; }
        public string State { get; set; }

        // Navigation
        [Required]
        [ForeignKey("MaterailId")]
        public int MaterailId { get; set; }
        public virtual Materails Materails { get; set; }
    }
}
