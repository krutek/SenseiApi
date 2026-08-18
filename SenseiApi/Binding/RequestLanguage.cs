using SenseiApi.Common;
using SenseiApi.Domain.Enums;
using System.Reflection;

namespace SenseiApi.Binding;

public readonly record struct RequestLanguage(Language Value)
{
    public static ValueTask<RequestLanguage?> BindAsync(
        HttpContext context,
        ParameterInfo parameter)
    {
        var languageCode = context.Request.Query["language"]
            .FirstOrDefault();


        if (!LanguageMapper.TryMap(languageCode, out var language))
        {
            return ValueTask.FromResult<RequestLanguage?>(null);
        }


        return ValueTask.FromResult<RequestLanguage?>(
            new RequestLanguage(language));
    }
}