using RickAndMortyBlazorV1.Dto;
using RickAndMortyBlazorV1.Enums;
using RickAndMortyBlazorV1.Models;

namespace RickAndMortyBlazorV1.Service
{
    public interface IRickAndMortyService
    {

        Task<Character> GetCharacter(int id);
        Task<PageDto<T>> GetSimplePages<T>(string path, int page = 0);
        Task<PageDto<Character>?> GetAllCharactersAsync(int page = 1, string searchTerm = "", string charStatus = "", string charGender = "");
        Task<IEnumerable<Character>> GetAllCharacters();
        Task<PageDto<T>> GetUrl<T>(string url);
        Task<IEnumerable<Character>> GetMultipleCharacters(int[] ids);
        Task<T>? GetSingleUrl<T>(string url);
        Task<IEnumerable<Character>> FilterCharacters(string name = "",
            CharacterStatus? characterStatus = null,
            string species = "",
            string type = "",
            CharacterGender? gender = null);
        Task<PageDto<Character>> FilterCharactersPage(string name = "",
            CharacterStatus? characterStatus = null,
            string species = "",
            string type = "",
            CharacterGender? gender = null);

        Task<IEnumerable<Location>> GetAllLocations();
        Task<IEnumerable<Location>> GetMultipleLocations(int[] ids);
        Task<Location> GetLocation(int id);
        Task<IEnumerable<Location>> FilterLocations(string name = "",
            string type = "",
            string dimension = "");

        Task<IEnumerable<Episode>> GetAllEpisodes();
        Task<Episode> GetEpisode(int id);
        Task<IEnumerable<Episode>> GetMultipleEpisodes(int[] ids);
        Task<IEnumerable<Episode>> FilterEpisodes(string name = "",
            string episode = "");
    }
}
