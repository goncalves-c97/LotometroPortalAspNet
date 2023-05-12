using System;

namespace LotometroPortal.Libraries.AspDataLibrary
{

    /// <summary>
    /// Classe de funções auxiliares
    /// </summary>
    public static class AuxiliarClass
    {
        /// <summary>
        /// Converter um objeto em string
        /// </summary>
        /// <param name="value">objeto</param>
        /// <returns>string que representa o objeto</returns>
        public static string ObjToStr(object value)
        {
            if (value != null)
            {
                try
                {
                    return value.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exceção ao ler string de objeto: {ex.Message}");
                }
            }
            else
                return null;
        }
    }
}
