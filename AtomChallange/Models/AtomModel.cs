using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJsonSchema;

namespace AtomChallange
{
    public class Atom
    {
        [Required]
        public int? number { get; set; }
        [MinLength(1),MaxLength(2),Required]
        public string? symbol { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public decimal? weight { get; set; }
    }
}
