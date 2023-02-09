using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMSystem.Core
{
    public class Materails
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Store { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descritpion { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double InCome { get; set; }
        [Required]
        public double OutCome { get; set; }
        [Required]
        public double Damge { get; set; }
        [Required]
        public double OutConscience { get; set; }
        [Required]
        public double ConscinceCard { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        public virtual List<Income> Income { get; set; }
        // Navigation 
        public int StoreId { get; set; }
        public Stores Stores { get; set; }

    }
}
