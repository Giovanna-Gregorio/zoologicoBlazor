using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zoologicoBlazor.Shared;

namespace zoologicoBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuidadorDetailsController : Controller
    {
        private readonly AppDbContext db;

        public CuidadorDetailsController(AppDbContext db)
        {
            this.db = db; //Injeção de Dependência!!!
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] CuidadorDetails cd)
        {
            try
            {
                var newCuidadorDetails = new CuidadorDetails
                {
                    Logradouro = cd.Logradouro,
                    Numero = cd.Numero,
                    Cidade = cd.Cidade,
                    Estado = cd.Estado,
                    CEP = cd.CEP,
                    Telefone = cd.Telefone,
                    IdCuidador = cd.IdCuidador
                };

                db.Add(newCuidadorDetails);
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