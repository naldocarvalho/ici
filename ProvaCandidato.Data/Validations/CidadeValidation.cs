using ProvaCandidato.Data.Entidade;
using System.Collections.Generic;

namespace ProvaCandidato.Data.Validations
{
    public class CidadeValidation
    {
        public static List<string> Validate(Cidade cidade)
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(cidade.Nome))
            {
                erros.Add("Nome não pode ser vazio.");
            }

            if (cidade.Nome?.Length < 3)
            {
                erros.Add("Nome deve ter no mínimo 3 caracteres.");
            }

            if (cidade.Nome?.Length > 50)
            {
                erros.Add("Nome deve ter no máximo 50 caracteres.");
            }

            return erros;
        }
    }
}