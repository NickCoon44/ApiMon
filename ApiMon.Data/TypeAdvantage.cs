using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Data
{
    public class TypeAdvantage
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Advantage))]
        public int AdvantageId { get; set; }
        public virtual ElementType Advantage { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Disadvantage))]
        public int DisadvantageId { get; set; }
        public virtual ElementType Disadvantage { get; set; }
    }
}
