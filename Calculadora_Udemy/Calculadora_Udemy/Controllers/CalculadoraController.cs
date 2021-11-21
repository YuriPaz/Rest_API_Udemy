using Microsoft.AspNetCore.Mvc;

namespace Calculadora_Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Soma(string primeiroNumero, string segundoNumero)
        {
            if (ENumeral(primeiroNumero) && ENumeral(segundoNumero))
            {
                var soma = (ConverterDecimal(primeiroNumero) + ConverterDecimal(segundoNumero));
                return Ok(soma.ToString());
            }
            return BadRequest("Valor de entrada inválido");
        }

        [HttpGet("sub/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Subtracao(string primeiroNumero, string segundoNumero)
        {
            if (ENumeral(primeiroNumero) && ENumeral(segundoNumero))
            {
                var sub = (ConverterDecimal(primeiroNumero) - ConverterDecimal(segundoNumero));
                return Ok(sub.ToString());
            }
            return BadRequest("Valor de entrada inválido");
        }

        [HttpGet("mult/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Multiplicacao(string primeiroNumero, string segundoNumero)
        {
            if (ENumeral(primeiroNumero) && ENumeral(segundoNumero))
            {
                var mult = (ConverterDecimal(primeiroNumero) * ConverterDecimal(segundoNumero));
                return Ok(mult.ToString());
            }
            return BadRequest("Valor de entrada inválido");
        }

        [HttpGet("divisao/{primeiroValor}/{segundoValor}")]
        public IActionResult Divisao(string primeiroNumero, string segundoNumero)
        {
            if (ENumeral(primeiroNumero) && ENumeral(segundoNumero))
            {
                if(ConverterDecimal(segundoNumero) != 0)
                {
                    var div = (ConverterDecimal(primeiroNumero) / ConverterDecimal(segundoNumero));
                    return Ok(div.ToString());
                }
                return BadRequest("Divisão por 0 (ZERO) não é possível");
            }
            return BadRequest("Valor de entrada inválido");
        }

        [HttpGet("media/{primeiroValor}/{segundoValor}")]
        public IActionResult Media(string primeiroNumero, string segundoNumero)
        {
            if (ENumeral(primeiroNumero) && ENumeral(segundoNumero))
            {
                var media = (ConverterDecimal(primeiroNumero) + ConverterDecimal(segundoNumero)) / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Valor de entrada inválido");
        }

        [HttpGet("raiz/{primeiroValor}")]
        public IActionResult Raiz(string numero)
        {
            if (ENumeral(numero))
            {
                ;
                var raiz = Math.Sqrt((double)ConverterDecimal(numero));
                return Ok(raiz.ToString());
            }
            return BadRequest("Valor de entrada inválido");
        }

        private bool ENumeral(string strNumero)
        {
            double numero;
            bool isNumero = double.TryParse(
                strNumero,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out numero);
            return isNumero;
        }

        private decimal ConverterDecimal(string strNumero)
        {
            decimal valorDecimal;
            if (decimal.TryParse(strNumero, out valorDecimal))
            {
                return valorDecimal;
            }
            return 0;
        }
    }
}