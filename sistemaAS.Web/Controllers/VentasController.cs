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


    public class VentasController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public VentasController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A VENTAS y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/VENTAS/EJEMPLO2
        [HttpGet("{idVenta}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);


            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idVenta")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            //valido que el id sea diferente
            if (id != venta.idVenta)
            {
                return BadRequest();
            }
            _context.Entry(venta).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (VentaExists(id))
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

        //EL METODO POST DE MI API PARA VENTAS

        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVenta", new { id = venta.idVenta }, venta);
        }
        //ahora un delete pero que sera un update para VENTAS

        [HttpDelete("idVenta")]
        public async Task<ActionResult<Venta>> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return venta;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(z => z.idVenta == id);
        }
    }
}