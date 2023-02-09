using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMSystem.Core
{
    public class OutCome
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OuterNo { get; set; }
        [Required]
        public DateTime OutDate { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public int MaterialNo { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public string User { get; set; }

        // Navigation
        public virtual List<OutComeMaterail> OutComeMaterails { get; set; }
    }
}
