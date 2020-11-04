using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zoologicoBlazor.Shared;

namespace zoologicoBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : Controller
    {
        private readonly AppDbContext db;

        public AnimalController(AppDbContext db)
        {
            this.db = db; //Injeção de Dependência!!!
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var animais = await db.Animais.ToListAsync();
            return Ok(animais);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var animal = await db.Animais.SingleOrDefaultAsync(x => x.IdAnimal == Convert.ToInt32(id));
            return Ok(animal);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] Animal animal)
        {
            try
            {
                var newAnimal = new Animal
                {
                    Nome = animal.Nome,
                    Idade = animal.Idade,
                    Peso = animal.Peso,
                    IdEspecie = animal.IdEspecie
                    //Convert.ToInt32(animal.IdEspecie)
                };

                db.Add(newAnimal);
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
        public async Task<IActionResult> Put([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(animal).State = EntityState.Modified;
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
        public async Task<ActionResult<Animal>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var animal = await db.Animais.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            db.Animais.Remove(animal);
            await db.SaveChangesAsync();
            return Ok(animal);
        }
    }
}