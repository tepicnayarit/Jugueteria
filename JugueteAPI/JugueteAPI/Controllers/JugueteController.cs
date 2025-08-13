using JugueteAPI.Data.JugueteAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JugueteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugueteController : ControllerBase
    {
        private readonly DataContext _context;
        public JugueteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Juguete>>> getJuguetes()
        {
            return Ok(await _context.Juguetes.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult<List<Juguete>>> CreateJuguete(Juguete juguete)
        {
            _context.Juguetes.Add(juguete);
            await _context.SaveChangesAsync();

            return Ok(await _context.Juguetes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Juguete>>> UpdateJuguete(Juguete juguete)
        {
            var dbJuguete = await _context.Juguetes.FindAsync(juguete.Id);
            if (dbJuguete == null)
                return BadRequest("Juguete no encontrado.");

            dbJuguete.Nombre = juguete.Nombre;
            dbJuguete.Descripcion = juguete.Descripcion;
            dbJuguete.RestriccionEdad = juguete.RestriccionEdad;
            dbJuguete.Compania = juguete.Compania;
            dbJuguete.Precio = juguete.Precio;
              
            await _context.SaveChangesAsync();

            return Ok(await _context.Juguetes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Juguete>>> DeleteJuguete(int id)
        {
            var dbJuguete = await _context.Juguetes.FindAsync(id);
            if (dbJuguete == null)
                return BadRequest("Juguete no encontrado.");

            _context.Juguetes.Remove(dbJuguete);
            await _context.SaveChangesAsync();

            return Ok(await _context.Juguetes.ToListAsync());
        }
    }//juguetecontroller
}//namespace
