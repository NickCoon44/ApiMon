using ApiMon.Data;
using ApiMon.Models.AdvantageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Services
{
    public class TypeAdvantageService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public bool CreateAdvantage(AdvantageCreate model)
        {
            var entity = new TypeAdvantage()
            {
                AdvantageId = model.AdvantageId,
                DisadvantageId = model.DisadvantageId
            };

            _context.TypeAdvantages.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public List<string> GetAllAdvantages()
        {
            var advantages = new List<string>();
            var entities = _context.TypeAdvantages.ToList();
            foreach(var Adv in entities)
            {
                advantages.Add($"{Adv.Advantage.Name} Has advantage over {Adv.Disadvantage.Name}");
            }
            return advantages;
        }

        public bool DeleteAdvantage(int originalAdvId, int originalDisId)
        {
            TypeAdvantage entity = _context.TypeAdvantages.Find(originalAdvId, originalDisId);
            if (entity is null)
                return false;

            _context.TypeAdvantages.Remove(entity);
            return _context.SaveChanges() == 1;
        }
    }
}
