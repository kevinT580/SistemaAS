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
    public class ArticulosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public ArticulosController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A ARTICULOS y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/ART./EJEMPLO2
        [HttpGet("{idarticulo}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);


            if (articulo == null)
            {
                return NotFound();
            }
            return articulo;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idarticulo")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            //valido que el id sea diferente
            if (id != articulo.idArticulo)
            {
                return BadRequest();
            }
            _context.Entry(articulo).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (ArticuloExists(id))
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

        //EL METODO POST DE MI API PARA ARTICULOS

        [HttpPost]
        public async Task<ActionResult<Articulo>> PostCategoria(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetArticulo", new { id = articulo.idArticulo }, articulo);
        }
        //ahora un delete pero que sera un update para ART.

        [HttpDelete("idArticulo")]
        public async Task<ActionResult<Articulo>> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return articulo;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(z => z.idArticulo == id);
        }
    }
}
