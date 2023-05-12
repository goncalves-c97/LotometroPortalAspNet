using System;
using System.Collections.Generic;

namespace LotometroPortal.Libraries.AspDataLibrary
{
    /// <summary>
    /// Classe que armazena e faz leituras de dados no TempData
    /// </summary>
    public static class TempDataManager
    {
        #region PROPERTIES

        /// <summary>
        /// Lista de chaves
        /// </summary>
        public static ICollection<string> KeysList { get => ServicesManager.TempData.Keys; }

        #endregion
        
        #region PUBLIC METHODS

        /// <summary>
        /// Salva uma string no TempData
        /// </summary>
        /// <param name="key">Enumerator utilizado como chave</param>
        /// <param name="value">Valor para armazenamento</param>
        public static void Set(Enum key, string value)
        {
            try
            {
                ServicesManager.TempData[key.ToString()] = value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exceção ao salvar chave: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui uma string no TempData
        /// </summary>
        /// <param name="key">Enumerator utilizado como chave</param>      
        public static void Del(Enum key)
        {
            try
            {
                ServicesManager.TempData.Remove(key.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception($"Exceção ao excluir chave: {ex.Message}");
            }
        }

        /// <summary>
        /// Lê e mantém uma string do TempData
        /// </summary>
        /// <param name="key">String utilizada como chave</param>        
        /// <returns>String salva ou null se não encontrar</returns>
        public static string Get(string key)
        {
            object value;

            try
            {
                value = ServicesManager.TempData[key];
            }
            catch (Exception ex)
            {
                throw new Exception($"Exceção ao ler conteúdo da chave: {ex.Message}");
            }


            if (value != null)
            {
                ServicesManager.TempData.Keep(key);
                return AuxiliarClass.ObjToStr(value);
            }
            else
                return null;
        }

        /// <summary>
        /// Lê e mantém uma string do TempData
        /// </summary>
        /// <param name="key">Enumerator utilizado como chave</param>        
        /// <returns>String salva ou null se não encontrar</returns>
        public static string Get(Enum key)
        {
            return Get(key.ToString());
        }

        /// <summary>
        /// Limpa todos os dados e objetos salvos em TempData
        /// </summary>
        public static void Clear()
        {
            ServicesManager.TempData.Clear();            
        }

        #endregion
    }
}
