using AspDataLibrary;
using LotometroPortal.Libraries.AspDataLibrary;
using LotometroPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LotometroPortal.Entities.EnumeratorsClass;

namespace LotometroPortal.Entities
{
    public class EntitiesHelperClass
    {
        private static AuthViewModel authObj;

        #region ERROR MESSAGE

        public static string GetErrorMessage()
        {
            return ViewDataManager.Get(TempDataKeys.errorMessage);
        }

        public static void SetErrorMessage(Controller ctrl, string value)
        {
            ViewDataManager.Set(ctrl, TempDataKeys.errorMessage, value);
        }

        public static void DelErrorMessage(Controller ctrl)
        {
            ViewDataManager.Set(ctrl, TempDataKeys.errorMessage, "");
        }

        #endregion

        #region INFO MESSAGE

        public static string GetInfoMessage()
        {
            return ViewDataManager.Get(TempDataKeys.infoMessage);
        }

        public static void SetInfoMessage(Controller ctrl, string value)
        {
            ViewDataManager.Set(ctrl, TempDataKeys.infoMessage, value);
        }

        public static void DelInfoMessage(Controller ctrl)
        {
            ViewDataManager.Set(ctrl, TempDataKeys.infoMessage, "");
        }

        #endregion

        #region SUCCESS MESSAGE

        public static string GetSuccessMessage()
        {
            return ViewDataManager.Get(TempDataKeys.successMessage);
        }

        public static void SetSuccessMessage(Controller ctrl, string value)
        {
            ViewDataManager.Set(ctrl, TempDataKeys.successMessage, value);
        }

        public static void DelSuccessMessage(Controller ctrl)
        {
            ViewDataManager.Set(ctrl, TempDataKeys.successMessage, "");
        }

        #endregion

        #region TOKEN

        public static string GetToken()
        {
            return TempDataManager.Get(TempDataKeys.token);
        }

        public static void SetToken(string value)
        {
            TempDataManager.Set(TempDataKeys.token, value);
        }

        #endregion

        #region USER

        public static void SetAuthObj(AuthViewModel newAuthObj)
        {
            authObj = newAuthObj;
        }

        public static AuthViewModel GetAuthObj()
        {
            return authObj;
        }

        #endregion

        #region DATETIME

        public static void SetInicioSessao(DateTime value)
        {
            TempDataManager.Set(TempDataKeys.startSessionDateTime, value.ToString());
        }

        public static string GetInicioSessao()
        {
            return TempDataManager.Get(TempDataKeys.startSessionDateTime);
        }

        #endregion

        #region PAGE
        public static string GetLastPage()
        {
            return TempDataManager.Get(TempDataKeys.lastPage);
        }

        public static void SetLastPage(string value)
        {
            TempDataManager.Set(TempDataKeys.lastPage, value);
        }
        #endregion
    }
}
