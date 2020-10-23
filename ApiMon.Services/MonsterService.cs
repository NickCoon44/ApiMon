using ApiMon.Data;
using ApiMon.Models;
using ApiMon.Models.MonsterModels;
using ApiMon.Models.MoveModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Services
{
    public class MonsterService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public bool CreateMonster(MonsterCreate model)
        {
            var entity = new Monster()
            {
                Name = model.Name,
                Description = model.Description,
                ElementTypeId = model.ElementTypeId,
                MoveOneId = model.MoveOneId,
                MoveTwoId = model.MoveTwoId,
                MoveThreeId = model.MoveThreeId,
                MoveFourId = model.MoveFourId
            };

            _context.Monsters.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<MonsterListItem> GetAllMonsters()
        {
            var query = _context.Monsters.Select(e => new MonsterListItem()
            {
                Id = e.Id,
                Name = e.Name,
                ElementType = e.ElementType.Name
            });
            return query.ToArray();
        }

        public MonsterDetail GetMonsterById(int id)
        {
            var entity = _context.Monsters.Find(id);
            if (entity is null)
                return null;
            var model = new MonsterDetail()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ElementType = entity.ElementType.Name,
                MoveOne = new MoveListItem()
                {
                    Id = entity.MoveOneId != null ? entity.MoveOneId : null,
                    Name = entity.MoveOne != null ? entity.MoveOne.Name : "none",
                    ElementType = entity.MoveOne != null ? entity.MoveOne.Name : "none"
                },
                MoveTwo = new MoveListItem()
                {
                    Id = entity.MoveTwoId != null ? entity.MoveTwoId : null,
                    Name = entity.MoveTwo != null ? entity.MoveTwo.Name : "none",
                    ElementType = entity.MoveTwo != null ? entity.MoveTwo.Name : "none"
                },
                MoveThree = new MoveListItem()
                {
                    Id = entity.MoveThreeId != null ? entity.MoveThreeId : null,
                    Name = entity.MoveThree != null ? entity.MoveThree.Name : "none",
                    ElementType = entity.MoveThree != null ? entity.MoveThree.Name : "none"
                },
                MoveFour = new MoveListItem()
                {
                    Id = entity.MoveFourId != null ? entity.MoveFourId : null,
                    Name = entity.MoveFour != null ? entity.MoveFour.Name : "none",
                    ElementType = entity.MoveFour != null ? entity.MoveFour.Name : "none"
                },
            };

            return model;
        }

        public bool UpdateMonster(int id, MonsterEdit model)
        {
            var entity = _context.Monsters.Single(e => e.Id == id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.ElementTypeId = model.ElementTypeId;
                entity.MoveOneId = model.MoveOneId;
                entity.MoveTwoId = model.MoveTwoId;
                entity.MoveThreeId = model.MoveThreeId;
                entity.MoveFourId = model.MoveFourId;

                return _context.SaveChanges() == 1;
            }
            return false;

        }

        public bool DeleteMonster(int id)
        {
            var entity = _context.Monsters.Single(e => e.Id == id);
            if (entity != null)
            {
                _context.Monsters.Remove(entity);
                return _context.SaveChanges() == 1;
            }
            return false;
        }
    }
}
