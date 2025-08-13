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
        public async Task<ActionResult<List<Juguete>>> CreateSuperHero(Juguete juguete)
        {
            _context.Juguetes.Add(juguete);
            await _context.SaveChangesAsync();

            return Ok(await _context.Juguetes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Juguete>>> UpdateSuperHero(Juguete juguete)
        {
            var dbHero = await _context.Juguetes.FindAsync(juguete.Id);
            if (dbHero == null)
                return BadRequest("Juguete no encontrado.");

            dbHero.Nombre = juguete.Nombre;
            dbHero.Descripcion = juguete.Descripcion;
            dbHero.RestriccionEdad = juguete.RestriccionEdad;
            dbHero.Compania = juguete.Compania;
            dbHero.Precio = juguete.Precio;
              
            await _context.SaveChangesAsync();

            return Ok(await _context.Juguetes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Juguete>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.Juguetes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Juguete no encontrado.");

            _context.Juguetes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Juguetes.ToListAsync());
        }
    }//juguetecontroller
}//namespace
