using Model.Validacao;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Temperatura
    {
        [DisplayName("Valor da Temperatura")]
        [Range(-1500, 1500, ErrorMessage = "O valor da temperatura deverá ser entre -1500 e 1500")]
        public double ValorTemperatura { get; set; }

        [StringLength(1)]
        [DisplayName("Unidade da Temperatura")]
        [ValidacaoTemperatura]
        public string Unidade { get; set; } = "C";


        public string CalcularTemperatura()
        {
            var temper = ConvertToCelsius();

            if (temper <= 0)
                return "Congelando";

            if (temper > 0 && temper < 15)
                return "Frio";

            if (temper > 15 && temper < 21)
                return "Fresquinho";

            if (temper > 21 && temper < 28)
                return "Calor";

            if (temper > 28 && temper < 40)
                return "Derretendo";

            if (temper > 40)
                return "O mundo já era Jesus ja pode voltar!";

            return "Temperatura inválida!";
        }

        private double ConvertToCelsius()
        {
            switch (Unidade)
            {
                case "C":
                    return ValorTemperatura;

                case "F":
                    return (ValorTemperatura - 32) * 5 / 9;

                case "K":
                    return ValorTemperatura - 273.15;

                default:
                    throw new Exception("Unidade de temperatura inválida!");
            }
        }
    }
}