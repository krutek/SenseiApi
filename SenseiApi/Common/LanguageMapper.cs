using SenseiApi.Domain.Enums;

namespace SenseiApi.Common
{
    public static class LanguageMapper
    {
        public static bool TryMap(string? code, out Language language)
        {
            language = code?.ToLowerInvariant() switch
            {
                "pl" => Language.Polish,
                "en" => Language.English,
                _ => default
            };

            return code is "pl" or "en";
        }
    }
}
