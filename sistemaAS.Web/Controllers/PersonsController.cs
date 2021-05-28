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
    public class PersonsController : Controller
    {
        private readonly DbContextSistema _context;
        public PersonsController(DbContextSistema context)
        {
            _context = context;
        }
        //NECESITO HACER LLAMADAS POR MEDIO DE LA API CON UN GET 
        //LE HAGO UN GET A PERSONA y trae todo lo que hay alli

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/PERSONAS/EJEMPLO2
        [HttpGet("{idPersona}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);


            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
        //funcion put sirve para mandar informacion a mi API/PRUEBA2
        [HttpPut("idPersona")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            //valido que el id sea diferente
            if (id != person.idPersona)
            {
                return BadRequest();
            }
            _context.Entry(person).State = EntityState.Modified;
            //a revisar que lo que subamos por medio de la api no sea basura
            try
            {
                await _context.SaveChangesAsync();
            }
            //ESTO PORQUE REVIERTE LA OPERACION SI EN CASO HAY ERROR
            //POR EJEMPLO QUE EL ID YA EXISTE.
            catch (DbUpdateConcurrencyException)
            {
                if (PersonExists(id))
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

        //EL METODO POST DE MI API PARA PERSONAS

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPerson", new { id = person.idPersona }, person);
        }
        //ahora un delete pero que sera un update para PERSONAS

        [HttpDelete("idPersona")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }


        //EVALUO CON UN BOOLEANO SI EXISTE
        private bool PersonExists(int id)
        {
            return _context.Persons.Any(z => z.idPersona == id);
        }
    }
}