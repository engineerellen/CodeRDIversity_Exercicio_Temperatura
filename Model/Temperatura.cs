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

        public Temperatura()
        {

        }

        public string CalcularTemperatura(double temp, string unidade)
        {
            var temper = ConvertToCelsius(temp, unidade);

            if (temper <= 0)
                return "Congelando";

            if (temper > 0 && temper < 15)
                return "Frio";

            if (temper > 15 && temper < 21)
                return "Fresquinho";

            if (temper > 21 && temper < 28)
                return "Calor";

            if (temper > 28)
                return "Derretendo";

            return "temperatura inválida!";
        }

        private double ConvertToCelsius(double temp, string unidade)
        {
            switch (unidade)
            {
                case "C":
                    return temp;

                case "F":
                    return (temp - 32) * 5 / 9;

                case "K":
                    return temp - 273.15;

                default:
                    throw new Exception("Unidade de temperatura inválida!");
            }
        }
    }
}