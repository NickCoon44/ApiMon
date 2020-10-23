using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models
{
    
    public class MonsterCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ElementTypeId { get; set; }
        public int MoveOneId { get; set; }
        public int MoveTwoId { get; set; }
        public int MoveThreeId { get; set; }
        public int MoveFourId { get; set; }
    }
}
