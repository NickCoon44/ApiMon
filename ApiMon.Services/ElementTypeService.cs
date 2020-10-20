using ApiMon.Data;
using ApiMon.Models.ElementTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Services
{
    class ElementTypeService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<ElementTypeListItem> GetElementTypes()
        {
            var query = _context.ElementTypes.Select(e => new ElementTypeListItem
            {
                Id = e.Id,
                Name = e.Name
            });
            return query;
        }
    }
}
