using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Data
{
    public class Monster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        // Element Type
        [Required]
        [ForeignKey(nameof(ElementType))]
        public int ElementTypeId { get; set; }
        public virtual ElementType ElementType { get; set; }

        // Move Slot 1
        [ForeignKey(nameof(MoveOne))]
        public int MoveOneId { get; set; }
        public virtual Move MoveOne { get; set; }

        // Move Slot 2
        [ForeignKey(nameof(MoveTwo))]
        public int MoveTwoId { get; set; }
        public virtual Move MoveTwo { get; set; }

        // Move Slot 3
        [ForeignKey(nameof(MoveThree))]
        public int MoveThreeId { get; set; }
        public virtual Move MoveThree { get; set; }

        // Move Slot 4
        [ForeignKey(nameof(MoveFour))]
        public int MoveFourId { get; set; }
        public virtual Move MoveFour { get; set; }
    }
}
