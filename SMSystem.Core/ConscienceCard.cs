using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMSystem.Core
{
    public class ConscienceCard
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DepName { get; set; }
        [Required]
        public string MaterialName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int OutComeNo { get; set; }
        [Required]
        public DateTime OutComeDate { get; set; }
        [Required]
        public string ReciverName { get; set; }
        [Required]
        public DateTime ReciverDate { get; set; }
        public string ReciverSign { get; set; }
        public string DepTransportName { get; set; }
        public string DepTransportReciverName { get; set; }
        public DateTime DepTransportReciverDate { get; set; }
        public string DepTransportReciverSign { get; set; }
        [Required]
        public DateTime AddDate { get; set; }

        // Navigations
        public int CustomerId { get; set; }
        public Customers customers { get; set; }
     
    }
}
