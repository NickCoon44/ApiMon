using ApiMon.Models.MoveModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.MonsterModels
{
    public class MonsterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ElementType { get; set; } // Name of ElementType
        public MoveListItem MoveOne { get; set; }
        public MoveListItem MoveTwo { get; set; }
        public MoveListItem MoveThree { get; set; }
        public MoveListItem MoveFour { get; set; }
    }
}
