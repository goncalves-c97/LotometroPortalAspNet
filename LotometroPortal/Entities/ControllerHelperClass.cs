
using LotometroPortal.ViewModels;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using LotometroPortal.Entities;
using LotometroPortal.Libraries.AspAuthenticationLibrary;

namespace LotometroPortal.Entities
{
    public class ControllerHelperClass
    {
        public static async Task<bool> SignInUser(AuthViewModel authViewModel, Controller controller)
        {
            if (authViewModel == null) // NÃO RETORNOU NENHUM USUÁRIO
            {
                EntitiesHelperClass.SetErrorMessage(controller, "Falha ao obter dados do usuário!");
                return false;
            }
            else // USUÁRIO RETORNADO COM SUCESSO
            {
                ClaimsPrincipal principal = AuthManager.GetPrincipalWithDefaultScheme(authViewModel.UserId); // CRIA O CLAIM PRINCIPAL COM OS VALORES
                AuthenticationProperties prop = AuthManager.GetProperties(1440); // CRIA O PROPERTIES COM TIMEOUT DE 1400 MINUTOS (24H = 24*60)
                await controller.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, prop);

                EntitiesHelperClass.SetInicioSessao(DateTime.Now); // GUARDA A DATA/HORA DE INICIO DE SESSÃO
                EntitiesHelperClass.SetAuthObj(authViewModel);
            }

            return true; // AUTENTICAÇÃO OK
        }

        public static async Task<bool> RegisterUser(AuthViewModel authViewModel, Controller controller)
        {
            if (authViewModel == null) // NÃO RETORNOU NENHUM USUÁRIO
            {
                EntitiesHelperClass.SetErrorMessage(controller, "Falha ao obter dados do usuário!");
                return false;
            }
            else // USUÁRIO RETORNADO COM SUCESSO
            {
                return true; // AUTENTICAÇÃO OK

            }
            
        }

        /// <summary>
        /// Salva os dados do usuário nas variáveis de sessão
        /// </summary>
        /// <param name="user">Objeto de usuário</param>
        private static void SetInfoAuthObj(AuthViewModel authObj)
        {
            //EntitiesHelperClass.SetUserID(user.ID);
            EntitiesHelperClass.SetAuthObj(authObj);
        }
    }
}
