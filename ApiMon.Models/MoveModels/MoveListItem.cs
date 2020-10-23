using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.MoveModels
{
    public class MoveListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ElementType { get; set; } //Name of Element Type
    }
}
