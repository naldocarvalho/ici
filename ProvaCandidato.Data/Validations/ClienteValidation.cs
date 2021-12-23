using ProvaCandidato.Data.Entidade;
using System.Collections.Generic;

namespace ProvaCandidato.Data.Validations
{
    public class ClienteValidation
    {
        public static List<string> Validate(Cliente cliente)
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(cliente.Nome))
            {
                erros.Add("Nome não pode ser vazio.");
            }

            if (cliente.Nome?.Length < 3)
            {
                erros.Add("Nome deve ter no mínimo 3 caracteres.");
            }

            if (cliente.Nome?.Length > 50)
            {
                erros.Add("Nome deve ter no máximo 50 caracteres.");
            }

            if (cliente.DataNascimento?.Date > System.DateTime.Now.Date)
            {
                erros.Add("Data de Nascimento não pode ser superior da data atual.");
            }

            return erros;
        }
    }
}