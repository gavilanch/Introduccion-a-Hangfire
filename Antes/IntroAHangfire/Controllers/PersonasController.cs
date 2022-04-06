using IntroAHangfire.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IntroAHangfire.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Crear(string nombrePersona)
        {
            Console.WriteLine($"agregando a la persona {nombrePersona}");
            var persona = new Persona { Nombre = nombrePersona };
            context.Add(persona);
            await Task.Delay(5000);
            await context.SaveChangesAsync();
            Console.WriteLine($"agregada la persona {nombrePersona}");
            return Ok();
        }
    }
}
