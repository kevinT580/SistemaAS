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
    public class RolesController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public RolesController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A ROL y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/ROL/EJEMPLO2
        [HttpGet("{idRol}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);


            if (rol == null)
            {
                return NotFound();
            }
            return rol;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idRol")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            //valido que el id sea diferente
            if (id != rol.idRol)
            {
                return BadRequest();
            }
            _context.Entry(rol).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (RolExists(id))
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

        //EL METODO POST DE MI API PARA ROLES

        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRol", new { id = rol.idRol }, rol);
        }
        //ahora un delete pero que sera un update para ROLES

        [HttpDelete("idRol")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return rol;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool RolExists(int id)
        {
            return _context.Roles.Any(z => z.idRol == id);
        }
    }
}
