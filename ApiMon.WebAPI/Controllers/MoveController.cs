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

        [HttpGet]
        public IHttpActionResult GetMoves()
        {
            var service = CreateMoveService();
            var moves = service.GetMoves();
            return Ok(moves);
        }

        [HttpGet]
        public IHttpActionResult GetMoveById(int id)
        {
            var service = CreateMoveService();

            var move = service.GetMoveById(id);
            return Ok(move);
        }

        [HttpPost]
        public IHttpActionResult CreateMove(MoveCreate move)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoveService();

            if (!service.CreateMove(move))
                return InternalServerError();

            return Ok(move.Name + " added");
        }

        [HttpPut]
        public IHttpActionResult UpdateMove([FromUri]int id, MoveEdit move)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoveService();

            if (!service.UpdateMove(id, move))
                return InternalServerError();

            return Ok($"Move {id} updated");
        }

        [HttpDelete]
        public IHttpActionResult DeleteMove(int id)
        {

            var service = CreateMoveService();

            if (!service.DeleteMove(id))
                return InternalServerError();

            return Ok($"Move {id} Deleted");
        }
    }
}
