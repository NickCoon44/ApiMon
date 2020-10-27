using ApiMon.Models.AdvantageModels;
using ApiMon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMon.WebAPI.Controllers
{
    public class TypeAdvantageController : ApiController
    {
        private TypeAdvantageService CreateAdvantageService()
        {
            return new TypeAdvantageService();
        }

        //Post
        [HttpPost]
        public IHttpActionResult CreateAdvantage(AdvantageCreate model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateAdvantageService();
            if (!service.CreateAdvantage(model))
                return InternalServerError();

            return Ok("Advantage Added");
        }

        //GetAll
        public IHttpActionResult GetAllAdvantages()
        {
            var service = CreateAdvantageService();
            var advantages = service.GetAllAdvantages();
            return Ok(advantages);
        }

        //Delete
        [HttpDelete]
        public IHttpActionResult DeleteAdvantage(int advantageId, int disadvantageId)
        {
            var service = CreateAdvantageService();
            if (service.DeleteAdvantage(advantageId, disadvantageId))
                return Ok();
            return InternalServerError();
        }
    }
}
