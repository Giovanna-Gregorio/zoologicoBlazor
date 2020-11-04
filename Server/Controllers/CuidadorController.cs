using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server;
using zoologicoBlazor.Shared;

namespace zoologicoBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuidadorController : Controller
    {
        private readonly AppDbContext db;

        public CuidadorController(AppDbContext db)
        {
            this.db = db; //Injeção de Dependência!!!
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var cuidador = await db.Cuidador.ToListAsync();
            return Ok(cuidador);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var cuidador = await db.Cuidador.SingleOrDefaultAsync(x => x.IdCuidador == Convert.ToInt32(id));
            return Ok(cuidador);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] Cuidador cuidador)
        {
            try
            {
                var newCuidador = new Cuidador
                {
                    Nome = cuidador.Nome,
                    Idade = cuidador.Idade,
                    Funcao = cuidador.Funcao,
                
                };

                db.Add(newCuidador);
                await db.SaveChangesAsync();//INSERT INTO
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Cuidador cuidador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(cuidador).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw (ex);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Cuidador>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cuidador = await db.Cuidador.FindAsync(id);
            if (cuidador == null)
            {
                return NotFound();
            }
            db.Cuidador.Remove(cuidador);
            await db.SaveChangesAsync();
            return Ok(cuidador);
        }
    }
}