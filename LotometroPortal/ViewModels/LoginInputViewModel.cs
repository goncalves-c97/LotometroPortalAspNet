using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LotometroPortal.ViewModels
{
    public class LoginInputViewModel
    {
        /// <summary>
        /// Dados digitados no campo username
        /// </summary>
        [Required(ErrorMessage = "O campo não pode ficar em branco."), StringLength(20, ErrorMessage = "O usuário não pode ter mais de 20 dígitos.")]
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Dados digitados no campo password
        /// </summary>
        [Required(ErrorMessage = "O campo não pode ficar em branco."), StringLength(20, ErrorMessage = "A senha não pode ter mais de 20 caracteres.")]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
