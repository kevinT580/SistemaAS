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
    public class IngresosController : Controller
    {
        private readonly DbContextSistema _context;
        public IngresosController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A INGRESO y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngresos()
        {
            return await _context.Ingresos.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/INGRESO/EJEMPLO2
        [HttpGet("{idIngreso}")]
        public async Task<ActionResult<Ingreso>> GetIngreso(int id)
        {
            var ingreso = await _context.Ingresos.FindAsync(id);


            if (ingreso == null)
            {
                return NotFound();
            }
            return ingreso;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idIngreso")]
        public async Task<IActionResult> PutIngreso(int id, Ingreso ingreso)
        {
            //valido que el id sea diferente
            if (id != ingreso.idIngreso)
            {
                return BadRequest();
            }
            _context.Entry(ingreso).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (IngresoExists(id))
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

        //EL METODO POST DE MI API PARA INGRESO

        [HttpPost]
        public async Task<ActionResult<Ingreso>> PostIngreso(Ingreso ingreso)
        {
            _context.Ingresos.Add(ingreso);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetIngreso", new { id = ingreso.idIngreso }, ingreso);
        }
        //ahora un delete pero que sera un update para INGRESOS

        [HttpDelete("idIngreso")]
        public async Task<ActionResult<Ingreso>> DeleteIngreso(int id)
        {
            var ingreso = await _context.Ingresos.FindAsync(id);
            if (ingreso == null)
            {
                return NotFound();
            }
            _context.Ingresos.Remove(ingreso);
            await _context.SaveChangesAsync();
            return ingreso;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(z => z.idIngreso == id);
        }
    }
}
