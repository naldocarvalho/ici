namespace ProvaCandidato.Data.Validations
{
    public class MensagemValidation
    {
        public enum EnumTipoMensagem
        {
            success = 1,
            error = 2,
            info = 3,
        }

        public string primaria { get; set; }
        public EnumTipoMensagem _tipo { get; set; }
        public string tipo
        {
            get
            {
                return _tipo.ToString();
            }
        }

        public MensagemValidation() { }

        /// <summary>
        /// Mensagem primaria de sucesso
        /// </summary>
        /// <param name="mensagem"></param>
        public MensagemValidation(string mensagemPrimaria)
        {
            this.primaria = mensagemPrimaria;
            this._tipo = EnumTipoMensagem.success;
        }

        /// <summary>
        /// Mensagem primaria por tipo
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="tipo"></param>
        public MensagemValidation(string mensagemPrimaria, EnumTipoMensagem tipo)
        {
            this.primaria = mensagemPrimaria;
            this._tipo = tipo;
        }
    }
}