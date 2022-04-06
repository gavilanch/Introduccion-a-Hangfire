using Hangfire;
using IntroAHangfire.Entidades;
using IntroAHangfire.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace IntroAHangfire.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IBackgroundJobClient backgroundJobClient;

        public PersonasController(ApplicationDbContext context, IBackgroundJobClient backgroundJobClient)
        {
            this.context = context;
            this.backgroundJobClient = backgroundJobClient;
        }

        [HttpPost("crear")]
        public ActionResult Crear(string nombrePersona)
        {
            //backgroundJobClient.Enqueue(() => Console.WriteLine(nombrePersona));
            backgroundJobClient.Enqueue<IRepositorioPersonas>(repo => repo.AgregarPersona(nombrePersona));
            return Ok();
        }

        [HttpPost("schedule")]
        public ActionResult Schedule(string nombrePersona)
        {
            var jobId = backgroundJobClient.Schedule(() => Console.WriteLine("El nombre es " + nombrePersona), TimeSpan.FromSeconds(5));
            backgroundJobClient.ContinueJobWith(jobId, () => Console.WriteLine($"El job {jobId} ha concluido"));
            return Ok();
        }

        //public async Task AgregarPersona(string nombrePersona)
        //{
        //    Console.WriteLine($"agregando a la persona {nombrePersona}");
        //    var persona = new Persona { Nombre = nombrePersona };
        //    context.Add(persona);
        //    await Task.Delay(5000);
        //    await context.SaveChangesAsync();
        //    Console.WriteLine($"agregada la persona {nombrePersona}");
        //}
    }
}
