using LotometroPortal.Entities;
using LotometroPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace LotometroPortal.Controllers
{
    public class CadastroController : Controller
    {
        public CadastroController()
        {
            EntitiesHelperClass.DelErrorMessage(this);
            EntitiesHelperClass.DelInfoMessage(this);
            EntitiesHelperClass.DelSuccessMessage(this);
        }

        /// <summary>
        /// Chama a view de Login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Click no botão de Cadastro
        /// </summary>
        /// <param name="registerInput">Dados do usuário</param>
        /// <returns></returns>
        [HttpPost, Route("v1/RegisterClick")]
        public async Task<IActionResult> RegisterClick(LoginInputViewModel registerInput)
        {
            if (!ModelState.IsValid) // ERRO NO PREENCHIMENTO DOS CAMPOS DO USUARIO_LOGIN
            {
                EntitiesHelperClass.SetErrorMessage(this, "Ocorreu um erro no cadastro, tente novamente por favor");
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

                    authObj = ApiHelperClass.RegisterIntoApi(registerInput);

                    
                    if (!await ControllerHelperClass.RegisterUser(authObj, this))
                        return View("Index");
                    else // AUTENTICAÇÃO OK
                    {
                        string controllerToCall = string.Empty;
                        EntitiesHelperClass.SetSuccessMessage(this, "Cadastrado com sucesso!");
                        return RedirectToAction("Index", "Login");
                        //return RedirectToAction("Index", "Dashboard");
                    }
                    
                }
                catch (Exception ex)
                {
                    EntitiesHelperClass.SetErrorMessage(this, ex.Message);
                    return View("Index");
                }
            }
        }
    }
}
