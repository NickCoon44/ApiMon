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
            var entity = _context.Monsters.Single(e => e.Id == id);
            var model = new MonsterDetail()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ElementType = entity.ElementType.Name,
                MoveOne = new MoveListItem()
                {
                    Id = entity.MoveOneId,
                    Name = entity.MoveOne.Name,
                    ElementType = entity.MoveOne.ElementType.Name
                },
                MoveTwo = new MoveListItem()
                {
                    Id = entity.MoveTwoId,
                    Name = entity.MoveTwo.Name,
                    ElementType = entity.MoveTwo.ElementType.Name
                },
                MoveThree = new MoveListItem()
                {
                    Id = entity.MoveThreeId,
                    Name = entity.MoveThree.Name,
                    ElementType = entity.MoveThree.ElementType.Name
                },
                MoveFour = new MoveListItem()
                {
                    Id = entity.MoveFourId,
                    Name = entity.MoveFour.Name,
                    ElementType = entity.MoveFour.ElementType.Name
                },
            };

            return model;
        }


    }
}
