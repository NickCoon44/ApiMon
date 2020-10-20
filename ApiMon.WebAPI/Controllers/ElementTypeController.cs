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
        public IHttpActionResult Post(ElementTypeCreate model)
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
            var Elements = service.GetElementTypes();
            return Ok(Elements);
        }



    }
}
