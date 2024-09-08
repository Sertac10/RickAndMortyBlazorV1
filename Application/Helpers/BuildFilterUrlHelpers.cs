using RickAndMortyBlazorV1.Enums;

namespace RickAndMortyBlazorV1.Helpers
{
    public static class BuildFilterUrlHelpers
    {


        public static string BuildCharacterFilterUrl(this string baseUrl,
       string name = "",
       CharacterStatus? status = null,
       string species = "",
       string type = "",
       CharacterGender? gender = null)
        {
            var url = baseUrl + "?";

            if (!string.IsNullOrEmpty(name)) url += $"{nameof(name)}={name}&";
            if (status.HasValue && status.Value != CharacterStatus.Alive) url += $"{nameof(status)}={status.Value}&";
            if (!string.IsNullOrEmpty(species)) url += $"{nameof(species)}={species}&";
            if (!string.IsNullOrEmpty(type)) url += $"{nameof(type)}={type}&";
            if (gender.HasValue && gender.Value != CharacterGender.Male) url += $"{nameof(gender)}={gender.Value}&";

            return url.TrimEnd('&');
        }
        public static string BuildLocationFilterUrl(this string baseUrl,
            string name = "",
            string type = "",
            string dimension = "")
        {
            return baseUrl + "?" +
            (!String.IsNullOrEmpty(name) ? $"{nameof(name)}={name}&" : "") +
            (!String.IsNullOrEmpty(type) ? $"{nameof(type)}={type}&" : "") +
            (!String.IsNullOrEmpty(dimension) ? $"{nameof(dimension)}={dimension}" : "");
        }
        public static string BuildEpisodeFilterUrl(this string baseUrl,
            string name = "",
            string episode = "")
        {
            return baseUrl + "?" +
            (!String.IsNullOrEmpty(name) ? $"{nameof(name)}={name}&" : "") +
            (!String.IsNullOrEmpty(episode) ? $"{nameof(episode)}={episode}&" : "");
        }
    }
}
