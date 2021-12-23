using ProvaCandidato.Data.Validations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProvaCandidato.Helper
{
    public static class MessageHelper
    {
        public static void DisplaySuccessMessage(Controller controller, string message)
        {
            var userMessage = new { CssClassName = "", Title = "Sucesso", Message = message };
            controller.TempData["UserMessage"] = message;
        }

        /// <summary>
        /// Lista de mensagens pendentes a serem exibidas
        /// </summary>
        public static List<MensagemValidation> MensagensToView = new List<MensagemValidation>();

        /// <summary>
        /// Método que adiciona uma mensagem de sucesso para a view
        /// </summary>
        /// <param name="mensagemPrimaria"></param>
        public static void AddMensagemToView(string mensagemPrimaria)
        {
            MensagensToView.Add(new MensagemValidation(mensagemPrimaria));
        }

        /// <summary>
        /// Método que adiciona uma mensagem para a view
        /// </summary>
        /// <param name="mensagemPrimaria"></param>
        /// <param name="tipo"></param>
        public static void AddMensagemToView(string mensagemPrimaria, MensagemValidation.EnumTipoMensagem tipo)
        {
            MensagensToView.Add(new MensagemValidation(mensagemPrimaria, tipo));
        }
    }
}