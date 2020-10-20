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
        public List<string> Advantages { get; set; }
        public List<string> Disadvantages { get; set; }
        public virtual ICollection<Monster> Monsters { get; set; }
        public virtual ICollection<Move> Moves { get; set; }
    }
}
