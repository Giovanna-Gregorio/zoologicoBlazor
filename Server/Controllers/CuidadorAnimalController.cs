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
    }
}