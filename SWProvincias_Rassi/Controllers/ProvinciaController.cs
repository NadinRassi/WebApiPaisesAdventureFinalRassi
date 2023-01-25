using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Rassi.Data;
using SWProvincias_Rassi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Rassi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {

        private readonly DBPaisContext context;

        public ProvinciaController(DBPaisContext context)
        {
            this.context = context;
        }
        /* GET */
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }


        /* POST */

        [HttpPost]
        public ActionResult Post(Provincia provincia) //INSERT
        {
            if (!ModelState.IsValid)//si no es valido
            {
                return BadRequest(ModelState);//digo error
            }
            context.Provincias.Add(provincia);//agrego
            context.SaveChanges();//y guardo
            return Ok();
        }



        /* PUT */
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;

            context.SaveChanges();
            return Ok();
        }


        /* DELETE */



    }
}
