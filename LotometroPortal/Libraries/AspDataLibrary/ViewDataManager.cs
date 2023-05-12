using LotometroPortal.Libraries.AspDataLibrary;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AspDataLibrary
{
    /// <summary>
    /// Classe que armazena e faz leituras de dados no ViewData
    /// </summary>
    public class ViewDataManager
    {
        #region PRIVATE OBJECTS

        private static Controller _ctrl;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Lista de chaves
        /// </summary>
        public static ICollection<string> KeysList
        {
            get
            {
                if (_ctrl == null)
                    return null;
                else
                    return _ctrl.ViewData.Keys;
            }
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Salva uma string no TempData
        /// </summary>
        /// <param name="ctrl">Controller que mantém o ViewData</param>
        /// <param name="key">Enumerator utilizado como chave</param>
        /// <param name="value">Valor para armazenamento</param>
        public static void Set(Controller ctrl, Enum key, string value)
        {
            try
            {
                _ctrl = ctrl;
                _ctrl.ViewData[key.ToString()] = value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exceção ao salvar chave: {ex.Message}");
            }
        }

        /// <summary>
        /// Salva uma string no controller atual
        /// </summary>
        /// <param name="key">Enumerator utilizado como chave</param>
        /// <param name="value">Valor para armazenamento</param>
        public static void SetCurrent(Enum key, string value)
        {
            try
            {   if (_ctrl != null)
                    _ctrl.ViewData[key.ToString()] = value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exceção ao salvar chave: {ex.Message}");
            }
        }
        /// <summary>
        /// Ler uma string
        /// </summary>
        /// <param name="key">Nome da chave do registro</param>
        /// <returns>String salva ou null se não encontrar</returns>
        public static string Get(string key)
        {
            object value;

            if (_ctrl == null)
                return null;
            else
            {
                try
                {
                    value = _ctrl.ViewData[key];
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exceção ao ler conteúdo da chave: {ex.Message}");
                }

                return AuxiliarClass.ObjToStr(value);
            }
        }

        /// <summary>
        /// Ler uma string 
        /// </summary>
        /// <param name="key">Enumerator utilizado como chave</param>        
        /// <returns>String salva ou null se não encontrar</returns>
        public static string Get(Enum key)
        {
            return Get(key.ToString());            
        }

        

        /// <summary>
        /// Salva um objeto qualquer
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto</typeparam>
        /// <param name="ctrl">Controller que mantém o ViewData</param>
        /// <param name="key">Enumerator utilizado como chave</param>
        /// <param name="obj">Objeto</param>
        public static void SetObject(Controller ctrl, Enum key, object obj)
        {
            Set(ctrl, key, JsonConvert.SerializeObject(obj));
        }

        /// <summary>
        /// Obtém um objeto
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="key">Enumerator utilizado como chave</param>        
        /// <returns>Objeto ou null se não encontrado</returns>
        public static T GetObject<T>(Enum key)
        {
            string value = Get(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        #endregion
    }
}
