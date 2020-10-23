using ApiMon.Models;
using ApiMon.Models.MonsterModels;
using ApiMon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMon.WebAPI.Controllers
{
    public class MonsterController : ApiController
    {
        private MonsterService CreateMonsterService()
        {
            var service = new MonsterService();
            return service;
        }

        [HttpGet]
        public IHttpActionResult GetMonsters()
        {
            var service = CreateMonsterService();
            var moves = service.GetAllMonsters();
            return Ok(moves);
        }

        [HttpGet]
        public IHttpActionResult GetMonsterById(int id)
        {
            var service = CreateMonsterService();

            var move = service.GetMonsterById(id);
            if (move is null)
                return NotFound();
            return Ok(move);
        }

        [HttpPost]
        public IHttpActionResult CreateMonster(MonsterCreate monster)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMonsterService();

            if (!service.CreateMonster(monster))
                return InternalServerError();

            return Ok(monster.Name + " added");
        }

        [HttpPut]
        public IHttpActionResult UpdateMonster([FromUri] int id, MonsterEdit monster)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMonsterService();

            if (!service.UpdateMonster(id, monster))
                return InternalServerError();

            return Ok($"Monster {id} updated");
        }

        [HttpDelete]
        public IHttpActionResult DeleteMonster(int id)
        {

            var service = CreateMonsterService();

            if (!service.DeleteMonster(id))
                return InternalServerError();

            return Ok($"Monster {id} Deleted");
        }
    }
}
