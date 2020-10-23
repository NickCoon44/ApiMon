using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.MonsterModels
{
    public class MonsterEdit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ElementTypeId { get; set; }
        public int MoveOneId { get; set; }
        public int MoveTwoId { get; set; }
        public int MoveThreeId { get; set; }
        public int MoveFourId { get; set; }
    }
}
