using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Data
{
    public class Move
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Monster> Monsters { get; set; }
        [ForeignKey(nameof(ElementType))]
        public int ElementTypeId { get; set; }
        public virtual ElementType ElementType { get; set; }
    }
}
