using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zoologicoBlazor.Shared;

namespace zoologicoBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecieController : Controller
    {
        private readonly AppDbContext db;

        public EspecieController(AppDbContext db)
        {
            this.db = db; //Injeção de Dependência!!!
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var especies = await db.Especies.ToListAsync();
            return Ok(especies);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var especie = await db.Especies.SingleOrDefaultAsync(x => x.IdEspecie == Convert.ToInt32(id));
            return Ok(especie);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] Especie especie)
        {
            try
            {
                var newEspecie = new Especie
                {
                    Descricao = especie.Descricao,
                };

                db.Add(newEspecie);
                await db.SaveChangesAsync();//INSERT INTO
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
    }
}