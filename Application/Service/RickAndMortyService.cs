using EnsureThat;
using RickAndMortyBlazorV1.Dto;
using RickAndMortyBlazorV1.Enums;
using RickAndMortyBlazorV1.Helpers;
using RickAndMortyBlazorV1.Models;

namespace RickAndMortyBlazorV1.Service
{
    public class RickAndMortyService : BaseService, IRickAndMortyService
    {
        public List<Episode> Episodes { get; set; }

        public RickAndMortyService(string baseAddress = "https://rickandmortyapi.com/") : base(baseAddress)
        {

        }

        public async Task<Character> GetCharacter(int id)
        {
            Ensure.Bool.IsTrue(id > 0);

            return await Get<Character>($"api/character/{id}");


        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await GetPages<Character>("api/character/");

        }

        public async Task<IEnumerable<Character>> GetMultipleCharacters(int[] ids)
        {
            Ensure.Bool.IsTrue(ids.Any());

            return await Get<IEnumerable<Character>>($"api/character/{string.Join(",", ids)}");


        }

        public async Task<PageDto<Character>> FilterCharactersPage(string name = "",
            CharacterStatus? characterStatus = null,
            string species = "",
            string type = "",
            CharacterGender? gender = null)
        {
            Ensure.Bool.IsTrue(!String.IsNullOrEmpty(name) || characterStatus != null ||
                               !String.IsNullOrEmpty(species) || !String.IsNullOrEmpty(type) || gender != null);
            var url = "/api/character/".BuildCharacterFilterUrl(name, characterStatus, species, type, gender);
            return await GetPage<Character>(url);

        }
        public async Task<IEnumerable<Character>> FilterCharacters(string name = "",
          CharacterStatus? characterStatus = null,
          string species = "",
          string type = "",
          CharacterGender? gender = null)
        {
            Ensure.Bool.IsTrue(!String.IsNullOrEmpty(name) || characterStatus != null ||
                               !String.IsNullOrEmpty(species) || !String.IsNullOrEmpty(type) || gender != null);
            var url = "/api/character/".BuildCharacterFilterUrl(name, characterStatus, species, type, gender);
            return await GetPages<Character>(url);

        }


        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await GetPages<Location>("api/location/");


        }

        public async Task<IEnumerable<Location>> GetMultipleLocations(int[] ids)
        {
            Ensure.Bool.IsTrue(ids.Any());

            return await Get<IEnumerable<Location>>($"api/location/{string.Join(",", ids)}");


        }

        public async Task<Location> GetLocation(int id)
        {
            Ensure.Bool.IsTrue(id > 0);

            return await Get<Location>($"api/location/{id}");

        }

        public async Task<IEnumerable<Location>> FilterLocations(string name = "",
            string type = "",
            string dimension = "")
        {
            Ensure.Bool.IsTrue(!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(type) || !String.IsNullOrEmpty(dimension));

            var url = "/api/location/".BuildLocationFilterUrl(name, type, dimension);

            return await GetPages<Location>(url);


        }

        public async Task<IEnumerable<Episode>> GetAllEpisodes()
        {
            return await GetPages<Episode>("api/episode/");


        }

        public async Task<Episode> GetEpisode(int id)
        {
            Ensure.Bool.IsTrue(id > 0);

            return await Get<Episode>($"api/episode/{id}");


        }

        public async Task<IEnumerable<Episode>> GetMultipleEpisodes(int[] ids)
        {
            Ensure.Bool.IsTrue(ids.Any());

            return await Get<IEnumerable<Episode>>($"api/episode/{string.Join(",", ids)}");


        }

        public async Task<IEnumerable<Episode>> FilterEpisodes(string name = "",
            string episode = "")
        {
            Ensure.Bool.IsTrue(!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(episode));

            var url = "/api/episode/".BuildEpisodeFilterUrl(name, episode);

            return await GetPages<Episode>(url);

        }

        Task<PageDto<Character>> IRickAndMortyService.GetSimplePages<Character>(string path, int page)
        {
            return GetSimplePages<Character?>(path, page);
        }

        Task<PageDto<Character>?> IRickAndMortyService.GetAllCharactersAsync(int page, string searchTerm, string charStatus, string charGender)
        {
            return GetAllCharactersAsync(page, searchTerm, charStatus, charGender);
        }

        async Task<PageDto<T>?> IRickAndMortyService.GetUrl<T>(string url)
        {
            return await GetUrl<T>(url);
        }

        Task<T>? IRickAndMortyService.GetSingleUrl<T>(string url)
        {
            return GetSingleUrl<T>(url);
        }
    }
}
