using System.ComponentModel.DataAnnotations;

namespace Model.Validacao
{
    internal class ValidacaoTemperatura : ValidationAttribute
    {
        //ErrorMessage
        public ValidacaoTemperatura() : base("{0} não é uma unidade de temperatura válida!")
        { }

        //Se  a temperatura estiver entre C, F e K, será uma temperatura valida
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string unidade = (string)value;

            bool valido = unidade == "C" || unidade == "F" || unidade == "K";

            if (!valido)
                return null;

            return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                , new string[] { validationContext.MemberName });
        }
    }
}