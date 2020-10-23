using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.MonsterModels
{
    public class MonsterListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ElementType { get; set; } // Name of ElementType
    }
}
