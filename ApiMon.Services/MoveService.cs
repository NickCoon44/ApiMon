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
                var query =
                    ctx
                        .Moves
                        .Select(
                            e =>
                                new MoveListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    Description = e.Description,
                                    ElementType = e.ElementType.Name
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
