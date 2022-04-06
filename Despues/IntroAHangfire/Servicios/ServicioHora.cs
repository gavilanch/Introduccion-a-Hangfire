namespace IntroAHangfire.Servicios
{
    public interface IServicioHora
    {
        void ImprimirHora();
    }


    public class ServicioHora: IServicioHora
    {
        private readonly ILogger<ServicioHora> logger;

        public ServicioHora(ILogger<ServicioHora> logger)
        {
            this.logger = logger;
        }

        public void ImprimirHora()
        {
            logger.LogInformation(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        }

    }
}
