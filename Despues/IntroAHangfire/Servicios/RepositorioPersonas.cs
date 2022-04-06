using IntroAHangfire.Entidades;

namespace IntroAHangfire.Servicios
{
    public interface IRepositorioPersonas
    {
        Task AgregarPersona(string nombrePersona);
    }

    public class RepositorioPersonas: IRepositorioPersonas
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<RepositorioPersonas> logger;

        public RepositorioPersonas(ApplicationDbContext context, ILogger<RepositorioPersonas> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task AgregarPersona(string nombrePersona)
        {
            logger.LogInformation($"agregando a la persona {nombrePersona} desde el servicio");
            var persona = new Persona { Nombre = nombrePersona };
            context.Add(persona);
            await Task.Delay(5000);
            await context.SaveChangesAsync();
            logger.LogInformation($"agregada la persona {nombrePersona} desde el servicio");
        }
    }
}
