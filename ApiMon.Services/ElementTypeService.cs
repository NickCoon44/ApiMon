using ApiMon.Data;
using ApiMon.Models.ElementTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Services
{
    public class ElementTypeService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        //Get All
        public IEnumerable<ElementTypeListItem> GetElementTypes()
        {
            var query = _context.ElementTypes.Select(e => new ElementTypeListItem
            {
                Id = e.Id,
                Name = e.Name
            });
            return query;
        }

        //Create
        public bool CreateElementType (ElementTypeCreate model)
        {
            var entity = new ElementType()
            {
                Name = model.Name,
                Advantages = model.Advantages,
                Disadvantages = model.Disadvantages
            };

            _context.ElementTypes.Add(entity);

            return _context.SaveChanges() == 1;
        }

        //Get by ID
        public ElementTypeDetail GetElementTypeById(int id)
        {
            var entity = _context.ElementTypes.Single(e => e.Id == id);

            var model = new ElementTypeDetail()
            {
                Id = entity.Id,
                Name = entity.Name,
                Advantages = entity.Advantages,
                Disadvantages = entity.Disadvantages
            };

            // TODO Add in Monsters and Moves Later

            return model;
        }

        public bool UpdateElementType(int id, ElementTypeUpdate model)
        {
            var entity = _context.ElementTypes.Single(e => e.Id == id);
            //If no Id found return false
            if (entity is null)
                return false;

            //Using null coalescing operators to check for user inputs
            entity.Name = model.Name ?? entity.Name;
            entity.Advantages = model.Advantages ?? entity.Advantages;
            entity.Disadvantages = model.Disadvantages ?? entity.Disadvantages;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteElementType(int id)
        {
            var entity = _context.ElementTypes.Single(e => e.Id == id);

            if (entity is null)
                return false;

            _context.ElementTypes.Remove(entity);
            return _context.SaveChanges() == 1;
        }
    }
}
