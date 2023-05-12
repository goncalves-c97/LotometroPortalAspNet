using LotometroPortal.Entities;
using LotometroPortal.Libraries.AspDataLibrary;
using LotometroPortal.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LotometroPortal.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            EntitiesHelperClass.DelErrorMessage(this);
            EntitiesHelperClass.DelInfoMessage(this);
            EntitiesHelperClass.DelSuccessMessage(this);
        }

        #region FUNÇÕES PRIVADAS

        #endregion

        /// <summary>
        /// Chama a view de Login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("v1/ExpiredSession")]
        public IActionResult ExpiredSession()
        {
            EntitiesHelperClass.SetErrorMessage(this, UriPathsAndConsts.expiredSessionMsg);
            return View("Index");
        }

        /// <summary>
        /// Click no botão de Login
        /// </summary>
        /// <param name="loginInput">Dados do usuário</param>
        /// <returns></returns>
        [HttpPost, Route("v1/LoginClick")]
        public async Task<IActionResult> LoginClick(LoginInputViewModel loginInput)
        {
            if (!ModelState.IsValid) // ERRO NO PREENCHIMENTO DOS CAMPOS DO USUARIO_LOGIN
            {
                EntitiesHelperClass.SetErrorMessage(this, "Username e/ou password inválidos!");
                return View("Index");
            }
            else
            {
                try
                {
                    AuthViewModel authObj = null;

                    string error = string.Empty;

                    if (!string.IsNullOrEmpty(error)) // VERIFICA SE DEU ERRO AO OBTER CLIENTE
                    {
                        EntitiesHelperClass.SetErrorMessage(this, error);
                        return View("Index");
                    }

                    authObj = ApiHelperClass.LoginIntoApi(loginInput);

                    if (!await ControllerHelperClass.SignInUser(authObj, this))
                        return View("Index");
                    else // AUTENTICAÇÃO OK
                    {
                        string controllerToCall = string.Empty;
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                catch (Exception ex)
                {
                    EntitiesHelperClass.SetErrorMessage(this, ex.Message);
                    return View("Index");
                }
            }
        }



        /// <summary>
        /// Solicitação de Logout
        /// </summary>
        /// <returns>View da página inicial</returns>
        [HttpGet, Route("v1/Logout")]
        public async Task<IActionResult> Logout()
        {
            TempDataManager.Clear(); // LIMPA OS DADOS DO TEMPDATA
            await HttpContext.SignOutAsync(); // FAZ O LOGOUT O USUÁRIO
            return RedirectToAction("Index", "Home"); // RETORNA PARA A PÁGINA INICIAL
        }

        /// <summary>
        /// Chama a view de Login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
