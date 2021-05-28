using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaAS.Datos;
using sistemaAS.Entidades.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaAS.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public CategoriasController(DbContextSistema context)
        {
            _context = context;
        }
       //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
       //LE HAGO UN GET A CATEGORIAS y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/CATEGORIAS/EJEMPLO2
        [HttpGet ("{idcategoria}")]
public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

           
            if(categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idcategoria")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            //valido que el id sea diferente
            if (id != categoria.idcategoria)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (CategoriaExists(id))
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

        //EL METODO POST DE MI API PARA CATEGORIAS

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCategoria", new { id = categoria.idcategoria }, categoria);
        }
        //ahora un delete pero que sera un update para categorias

        [HttpDelete("idCategoria")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if(categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(b => b.idcategoria == id);
        }
        }
}
