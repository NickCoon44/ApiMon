﻿using ApiMon.Data;
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
        public int CreateMonster(MonsterCreate model)
        {
            if (CheckMove(model.MoveOneId, model.MoveTwoId, model.MoveThreeId, model.MoveFourId))
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
                return _context.SaveChanges(); // Should be 1
            }
            return 0;
        }

        private bool CheckMove(int a, int b, int c, int d)
        {

            if (a == b || a == c || a == d || b == c || b == d || c == d)
            {
                return false;
            }
            return true;
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
                    ElementType = entity.MoveOne != null ? entity.MoveOne.ElementType.Name : "none"
                },
                MoveTwo = new MoveListItem()
                {
                    Id = entity.MoveTwoId != null ? entity.MoveTwoId : null,
                    Name = entity.MoveTwo != null ? entity.MoveTwo.Name : "none",
                    ElementType = entity.MoveTwo != null ? entity.MoveTwo.ElementType.Name : "none"
                },
                MoveThree = new MoveListItem()
                {
                    Id = entity.MoveThreeId != null ? entity.MoveThreeId : null,
                    Name = entity.MoveThree != null ? entity.MoveThree.Name : "none",
                    ElementType = entity.MoveThree != null ? entity.MoveThree.ElementType.Name : "none"
                },
                MoveFour = new MoveListItem()
                {
                    Id = entity.MoveFourId != null ? entity.MoveFourId : null,
                    Name = entity.MoveFour != null ? entity.MoveFour.Name : "none",
                    ElementType = entity.MoveFour != null ? entity.MoveFour.ElementType.Name : "none"
                },
            };

            return model;
        }

        public int UpdateMonster(int id, MonsterEdit model)
        {
            var entity = _context.Monsters.Find(id);

            if (CheckMove(model.MoveOneId, model.MoveTwoId, model.MoveThreeId, model.MoveFourId))
            {
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.ElementTypeId = model.ElementTypeId;
                    if (entity.MoveTwoId != model.MoveOneId && entity.MoveThreeId != model.MoveOneId && entity.MoveFourId != model.MoveOneId)
                    {
                        entity.MoveOneId = model.MoveOneId;
                    }

                    if (entity.MoveOneId != model.MoveTwoId && entity.MoveThreeId != model.MoveTwoId && entity.MoveFourId != model.MoveTwoId)
                    {
                        entity.MoveTwoId = model.MoveTwoId;
                    }

                    if (entity.MoveOneId != model.MoveThreeId && entity.MoveTwoId != model.MoveThreeId && entity.MoveFourId != model.MoveThreeId)
                    {
                        entity.MoveThreeId = model.MoveThreeId;
                    }

                    if (entity.MoveOneId != model.MoveFourId && entity.MoveTwoId != model.MoveFourId && entity.MoveThreeId != model.MoveFourId)
                    {
                        entity.MoveFourId = model.MoveFourId;
                    }

                    return _context.SaveChanges(); // Should be 1
                }

            }
            return 0;

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
