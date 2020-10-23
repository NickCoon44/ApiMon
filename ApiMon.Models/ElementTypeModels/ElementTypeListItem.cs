using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Models.ElementTypeModels
{
    public class ElementTypeListItem
    {
        [Display(Name = "ElementId")]
        public int Id { get; set; }

        [Display(Name = "Element Name")]
        public string Name { get; set; }
    }
}
