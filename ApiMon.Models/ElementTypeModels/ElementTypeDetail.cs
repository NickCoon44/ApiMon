using ApiMon.Models.AdvantageModels;
using ApiMon.Models.MonsterModels;
using ApiMon.Models.MoveModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.ElementTypeModels
{
    public class ElementTypeDetail
    {
        [Display(Name = "Element Id")]
        public int Id { get; set; }

        [Display(Name = "Element Id")]
        public string Name { get; set; }

        public List<AdvantageListItem> Advantages { get; set; } = new List<AdvantageListItem>();

        public List<AdvantageListItem> Disadvantages { get; set; } = new List<AdvantageListItem>();

        public List<MonsterListItem> Monsters { get; set; } = new List<MonsterListItem>();
        public List<MoveListItem> Moves { get; set; } = new List<MoveListItem>();
}
}
