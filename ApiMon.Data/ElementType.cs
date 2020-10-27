using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Data
{
    public class ElementType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<TypeAdvantage> Advantages { get; set; } = new List<TypeAdvantage>();
        public virtual ICollection<TypeAdvantage> Disadvantages { get; set; } = new List<TypeAdvantage>();
        public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();
        public virtual ICollection<Move> Moves { get; set; } = new List<Move>();
    }
}
