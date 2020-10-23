using ApiMon.Data;
using ApiMon.Models.MoveModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMon.Services
{
    public class MoveService
    {
        public bool CreateMove(MoveCreate model)
        {
            var entity =
                new Move()
                {
                    Name = model.Name,
                    Description = model.Description,
                    ElementTypeId = model.ElementTypeId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Moves.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MoveListItem> GetMoves()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                        .Moves
                        .Select(e => new MoveListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            ElementType = e.ElementType.Name
                        });

                return query.ToArray();
            }
        }

        public MoveDetail GetMoveById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Moves.Single(e => e.Id == id);
                var model = new MoveDetail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    ElementTypeId = entity.ElementTypeId,
                    ElementTypeName = entity.ElementType.Name
                };
                return model;
            }

        }

        public bool UpdateMove(int id, MoveEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Moves.Single(e => e.Id == id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }

        public bool DeleteMove(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Moves.Single(e => e.Id == id);
                if (entity != null)
                {
                    ctx.Moves.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }

    }
}
