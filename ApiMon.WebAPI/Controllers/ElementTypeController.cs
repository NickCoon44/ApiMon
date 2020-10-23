using ApiMon.Models.ElementTypeModels;
using ApiMon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiMon.WebAPI.Controllers
{
    public class ElementTypeController : ApiController
    {
        private ElementTypeService CreateElementTypeService()
        {
            return new ElementTypeService();
        }

        //Post Element Type
        [HttpPost]
        public IHttpActionResult CreateElement(ElementTypeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateElementTypeService();

            if (!service.CreateElementType(model))
                return InternalServerError();

            return Ok($"{model.Name} added");
        }

        //Get All ElementTypes
        public IHttpActionResult Get()
        {
            var service = CreateElementTypeService();
            var elements = service.GetElementTypes();
            return Ok(elements);
        }

        //Get By Id
        public IHttpActionResult Get(int id)
        {
            var service = CreateElementTypeService();
            var element = service.GetElementTypeById(id);
            if (element is null)
                return NotFound();
            return Ok(element);
        }

        //Update Element By Id
        [HttpPut]
        public IHttpActionResult UpdateElementById([FromUri] int id, ElementTypeUpdate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateElementTypeService();

            switch (service.UpdateElementType(id, model))
            {
                case 0: return Ok("Element Updated");
                case 1: return InternalServerError();
                case 2: return NotFound();
                default: return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteElement(int id)
        {
            var service = CreateElementTypeService();

            if (service.DeleteElementType(id))
                return Ok();
            return InternalServerError();
        }

    }
}
