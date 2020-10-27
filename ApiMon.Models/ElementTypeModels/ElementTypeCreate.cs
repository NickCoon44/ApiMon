using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.ElementTypeModels
{
    public class ElementTypeCreate
    {
        [Required]
        public string Name { get; set; }

        //[Required]
        //public string Advantages { get; set; }

        //[Required]
        //public string Disadvantages { get; set; }
    }
}
