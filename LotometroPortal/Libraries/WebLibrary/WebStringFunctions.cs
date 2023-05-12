using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LotometroPortal.Libraries.WebLibrary
{
    public class WebStringFunctions
    {
        /// <summary>
        /// Resolve um problema de envio de strings do C# para o Javascript (caractéres especiais), 
        /// basicamente recebe uma string advinda do C# e devolve num formato que o Javascript exiba corretamente
        /// os caractéres especiais
        /// </summary>
        /// <param name="stringToConvert">String a ser tratada para o Javascript</param>
        /// <returns></returns>
        public static HtmlString GetTreatedStringForJavascript(string stringToConvert)
        {

            if (string.IsNullOrEmpty(stringToConvert))
                return null;
            else
            {
                if (stringToConvert.StartsWith("\"") && stringToConvert.EndsWith("\""))
                    stringToConvert = stringToConvert.Substring(1, stringToConvert.Length - 2);

                return new HtmlString(HttpUtility.JavaScriptStringEncode(stringToConvert));
            }
        }
    }
}
