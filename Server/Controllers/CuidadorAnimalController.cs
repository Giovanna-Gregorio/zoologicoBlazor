using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zoologicoBlazor.Shared;

namespace zoologicoBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuidadorAnimalController : Controller
    {
        private readonly AppDbContext db;

        public CuidadorAnimalController(AppDbContext db)
        {
            this.db = db; //Injeção de Dependência!!!
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var cuidadorAnimais = await db.CuidadorAnimais.ToListAsync();
            return Ok(cuidadorAnimais);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cuidadorAnimais = await db.CuidadorAnimais.FindAsync(id);
            return Ok(cuidadorAnimais);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] CuidadorAnimal ca)
        {
            try
            {
                // var pedido = new Pedido{
                //     DataPedido = DateTime.Now,
                //     Usuario = null
                // };

                var newDp = new CuidadorAnimal
                {
                    //Pedido = pedido,
                    //Produto = db.Products.FirstOrDefault(c => c.ProductId == Convert.ToInt32(dp.ProdutoId)),
                    IdAnimal = ca.IdAnimal,
                    IdCuidador = ca.IdCuidador,
                    Observacoes = ca.Observacoes
                };

                db.Add(newDp);
                await db.SaveChangesAsync();//INSERT INTO
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<CuidadorAnimal>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ca = await db.CuidadorAnimais.FindAsync(id);
            if (ca == null)
            {
                return NotFound();
            }
            db.CuidadorAnimais.Remove(ca);
            await db.SaveChangesAsync();
            return Ok(ca);
        }
    }
}