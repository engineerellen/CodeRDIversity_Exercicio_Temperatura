using Microsoft.AspNetCore.Mvc;
using Model;

namespace TemperaturaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        Temperatura objTemperatura;
        public TemperaturaController() => objTemperatura = new Temperatura();

        // o nosso get vai sempre retornar em graus celsius
        [HttpGet("{valorTemperatura}")]
        public string Get(double valorTemperatura)
        {
            objTemperatura.ValorTemperatura = valorTemperatura;
            return objTemperatura.CalcularTemperatura();
        }

        // aqui vai poder calcular em qualquer unidade
        [HttpPost]
        public string Post([FromBody] Temperatura temp)
        {
            return temp.CalcularTemperatura();
        }
    }
}