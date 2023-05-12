using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace LotometroPortal.Libraries.AspDataLibrary
{
    /// <summary>
    /// Classe de acesso a diversos serviços da aplicação
    /// </summary>
    public static class ServicesManager
    {
        /// <summary>
        /// Serviços da aplicação
        /// </summary>
        private static IServiceProvider services = null;

        /// <summary>
        /// Acesso ao Services da aplicação
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                    throw new Exception("Can't set once a value has already been set.");
                else
                    services = value;
            }
        }

        /// <summary>
        /// Acesso ao Context da aplicação
        /// </summary>
        public static HttpContext Context
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        /// <summary>
        /// Acesso ao TempData da aplicação
        /// </summary>
        public static ITempDataDictionary TempData
        {
            get
            {                
                ITempDataDictionaryFactory factory = services.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;                
                return factory.GetTempData(Context);
            }
        }       
    }
}
