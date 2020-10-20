﻿using System;
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
        [ForeignKey(nameof(ElementType))]
        public int ElementTypeId { get; set; }
        public virtual ElementType ElementType { get; set; }
        [ForeignKey(nameof(Move))]
        public int MoveOne { get; set; }
        [ForeignKey(nameof(Move))]
        public int MoveTwo { get; set; }
        [ForeignKey(nameof(Move))]
        public int MoveThree { get; set; }
        [ForeignKey(nameof(Move))]
        public int MoveFour { get; set; }
        public virtual Move Move { get; set; }
    }
}
