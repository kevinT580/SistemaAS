using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaAS.Datos;
using sistemaAS.Entidades.Sales;
using sistemaAS.Entidades.Wherehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaAS.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentasController : Controller
    {
        private readonly DbContextSistema _context;
        public DetalleVentasController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A detallventa y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetDetalleventas()
        {
            return await _context.DetalleVentas.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/detalleventa/EJEMPLO2
        [HttpGet("{idDetalleVenta}")]
        public async Task<ActionResult<DetalleVenta>> GetDetalleVenta(int id)
        {
            var detalleventa = await _context.DetalleVentas.FindAsync(id);


            if (detalleventa == null)
            {
                return NotFound();
            }
            return detalleventa;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idDetalleVenta")]
        public async Task<IActionResult> PutDetalleVenta(int id, DetalleVenta detalleventa)
        {
            //valido que el id sea diferente
            if (id != detalleventa.idDetalleVenta)
            {
                return BadRequest();
            }
            _context.Entry(detalleventa).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (DetalleVentaExists(id))
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

        //EL METODO POST DE MI API PARA detalleventa

        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> PostDetalleVenta(DetalleVenta detalleventa)
        {
            _context.DetalleVentas.Add(detalleventa);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDetalleVenta", new { id = detalleventa.idDetalleVenta }, detalleventa);
        }
        //ahora un delete pero que sera un update para detalle venta

        [HttpDelete("idDetalleVenta")]
        public async Task<ActionResult<DetalleVenta>> DeleteDetalleVenta(int id)
        {
            var detalleventa = await _context.DetalleVentas.FindAsync(id);
            if (detalleventa == null)
            {
                return NotFound();
            }
            _context.DetalleVentas.Remove(detalleventa);
            await _context.SaveChangesAsync();
            return detalleventa;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool DetalleVentaExists(int id)
        {
            return _context.DetalleVentas.Any(z => z.idDetalleVenta == id);
        }
    }
}
