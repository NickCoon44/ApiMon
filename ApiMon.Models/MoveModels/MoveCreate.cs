﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.MoveModels
{
    public class MoveCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ElementTypeId { get; set; }
    }
}
