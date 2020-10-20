using ApiMon.Models.MoveModels;
using ApiMon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMon.WebAPI.Controllers
{
    public class MoveController : ApiController
    {
        private MoveService CreateMoveService()
        {
            var moveService = new MoveService();
            return moveService;
        }

        public IHttpActionResult Get()
        {
            var moveService = CreateMoveService();
            var moves = moveService.GetMoves();
            return Ok(moves);
        }

        public IHttpActionResult Post(MoveCreate move)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoveService();

            if (!service.CreateMove(move))
                return InternalServerError();

            return Ok(move.Name + " added");
        }
    }
}
