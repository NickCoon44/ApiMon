using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.AdvantageModels
{
    public class AdvantageCreate
    {
        [Required]
        public int AdvantageId { get; set; }

        [Required]
        public int DisadvantageId { get; set; }
    }
}
