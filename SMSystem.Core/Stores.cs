
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMSystem.Core
{
    public class Stores
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Materails> Materails { get; set; }
    }
}
