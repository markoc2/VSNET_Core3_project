using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VBNET_Core3_project.Models;
using VBNET_Core3_project.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VBNET_Core3_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiConsulta : ControllerBase
    {

        private readonly MyDbContext _mydbcontext;
       
        public ApiConsulta(MyDbContext  mydbcontext)
        {
            _mydbcontext = mydbcontext;
        }

        // GET: api/<ConsultaController>
        [HttpGet]
        public IEnumerable<string> Get( )
        { 
             return new string[] { "value1", "value2" }; 
        }

        // GET api/<ConsultaController>/5
        [HttpGet("{id}")]
        public IEnumerable<VistaPrestamos> Get(int id)
        {
            var prestamos = (from pe in _mydbcontext.prestamos
                             join c in _mydbcontext.clientes on pe.IdCliente equals c.IdCliente
                             join t in _mydbcontext.tipoprestamos on pe.IdTipoPrestamo equals t.IdTipoPrestamo
                             where c.IdCliente == id
                             select new VistaPrestamos
                             {
                                 IdPrestamo = pe.IdPrestamo,
                                 IdCliente = pe.IdCliente,
                                 IdTipoPrestamo = pe.IdTipoPrestamo,
                                 Tipo = t.Tipo,
                                 Monto = pe.Monto,
                                 Interes = pe.Interes,
                                 Plazo = pe.Plazo,
                                 FechaCreacion = pe.FechaCreacion,
                                 CreadoPor = pe.CreadoPor,
                                 EstadoPrestamo = pe.EstadoPrestamo,
                                 Nombre = c.Nombre,
                                 Apellido = c.Apellido,
                                 Telefono = c.Telefono,
                                 Cedula = c.Cedula
                             }).ToList();

            if (prestamos == null) { 
                return null;
            }

            return prestamos;
        }

        // POST api/<ConsultaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConsultaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
