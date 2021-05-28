using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaAS.Datos;
using sistemaAS.Entidades.Purchases;
using sistemaAS.Entidades.Wherehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaAS.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DetalleIngresosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public DetalleIngresosController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A Detalle ingresos y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleIngreso>>> GetDetalleIngresos()
        {
            return await _context.DetalleIngresos.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/detalleingreso/EJEMPLO2
        [HttpGet("{idDetalleIngreso}")]
        public async Task<ActionResult<DetalleIngreso>> GetDetalleIngreso(int id)
        {
            var detalleingreso = await _context.DetalleIngresos.FindAsync(id);


            if (detalleingreso == null)
            {
                return NotFound();
            }
            return detalleingreso;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idDetalleIngreso")]
        public async Task<IActionResult> PutDetalleIngreso(int id, DetalleIngreso detalleingreso)
        {
            //valido que el id sea diferente
            if (id != detalleingreso.idDetalleIngreso)
            {
                return BadRequest();
            }
            _context.Entry(detalleingreso).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (DetalleIngresoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //EL METODO POST DE MI API PARA detalle ingresos

        [HttpPost]
        public async Task<ActionResult<DetalleIngreso>> PostCategoria(DetalleIngreso detalleingreso)
        {
            _context.DetalleIngresos.Add(detalleingreso);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDetalleIngreso", new { id = detalleingreso.idDetalleIngreso }, detalleingreso);
        }
        //ahora un delete pero que sera un update para detalleingresos

        [HttpDelete("idDetalleIngreso")]
        public async Task<ActionResult<DetalleIngreso>> DeleteCategoria(int id)
        {
            var detalleingreso = await _context.DetalleIngresos.FindAsync(id);
            if (detalleingreso == null)
            {
                return NotFound();
            }
            _context.DetalleIngresos.Remove(detalleingreso);
            await _context.SaveChangesAsync();
            return detalleingreso;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool DetalleIngresoExists(int id)
        {
            return _context.DetalleIngresos.Any(z => z.idDetalleIngreso == id);
        }
    }
}
