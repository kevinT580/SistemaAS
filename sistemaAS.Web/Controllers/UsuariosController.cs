using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaAS.Datos;
using sistemaAS.Entidades.Users;
using sistemaAS.Entidades.Wherehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaAS.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

       private readonly DbContextSistema _context;
        public UsuariosController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A USUARIO y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/USUARIOS/EJEMPLO2
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);


            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idUsuario")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            //valido que el id sea diferente
            if (id != usuario.idUsuario)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (UsuarioExists(id))
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

        //EL METODO POST DE MI API PARA USUARIOS

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostCategoria(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsuario", new { id = usuario.idUsuario }, usuario);
        }
        //ahora un delete pero que sera un update para USUARIOS

        [HttpDelete("idUsuario")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(z => z.idUsuario == id);
        }
    }
}
