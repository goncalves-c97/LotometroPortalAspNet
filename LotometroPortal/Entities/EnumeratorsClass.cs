using System;

namespace LotometroPortal.Entities
{
    public static class EnumeratorsClass
    {
        public static string EnumToStr(Enum value)
        {
            return value.ToString();
        }

        public enum TempDataKeys
        {
            errorMessage
                , infoMessage
                , successMessage
                , startSessionDateTime
                , token
                , lastPage
        }
    }
}
