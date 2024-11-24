using Microsoft.AspNetCore.Mvc;
using BibliotecaBackend.Models;
using System.Collections.Generic;

namespace BibliotecaBackend
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private static List<Libro> Libros = new List<Libro>
        {
            new Libro { Id = 1, Nombre = "Libro1", Precio = 9.9 },
            new Libro { Id = 2, Nombre = "Libro2", Precio = 9.9 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return Ok(Libros);
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> Get(int id)
        {
            var Libro = Libros.Find(p => p.Id == id);
            if (Libro == null)
            {
                return NotFound();
            }
            return Ok(Libro);
        }

        [HttpPost]
        public ActionResult<Libro> Post([FromBody] Libro newLibro)
        {
            newLibro.Id = Libros.Count + 1;
            Libros.Add(newLibro);
            return CreatedAtAction(nameof(Get), new { id = newLibro.Id }, newLibro);
        }

        [HttpPut("{id}")]
        public ActionResult<Libro> Put(int id, [FromBody] Libro updatedLibro)
        {
            var Libro = Libros.Find(p => p.Id == id);
            if (Libro == null)
            {
                return NotFound();
            }
            Libro.Nombre = updatedLibro.Nombre;
            Libro.Precio = updatedLibro.Precio;
            return Ok(Libro);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Libro = Libros.Find(p => p.Id == id);
            if (Libro == null)
            {
                return NotFound();
            }
            Libros.Remove(Libro);
            return NoContent();
        }
    }
}
