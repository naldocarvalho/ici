using System.Collections.Generic;

namespace ProvaCandidato.Data.Validations
{
    public abstract class GenericValidation<T> where T : class
    {
        public static List<string> Validate(T model)
        {
            List<string> erros = new List<string>();

            return erros;
        }
    }
}