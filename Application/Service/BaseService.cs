
using EnsureThat;
using Newtonsoft.Json;
using RickAndMortyBlazorV1.Dto;
using RickAndMortyBlazorV1.Helpers;
using RickAndMortyBlazorV1.Models;

namespace RickAndMortyBlazorV1.Service
{
    public abstract class BaseService
    {
        private HttpClient Client { get; }

        protected BaseService(string baseAddress)
        {

            Ensure.Bool.IsTrue(Uri.IsWellFormedUriString(baseAddress, UriKind.RelativeOrAbsolute));

            Client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        protected async Task<PageDto<Character>> GetAllCharactersAsync(int page = 1, string searchTerm = "", string charStatus = "", string charGender = "")
        {
            var queryParams = $"?page={page}";
            if (!string.IsNullOrEmpty(searchTerm)) queryParams += $"&name={searchTerm}";
            if (!string.IsNullOrEmpty(charStatus)) queryParams += $"&status={charStatus}";
            if (!string.IsNullOrEmpty(charGender)) queryParams += $"&gender={charGender}";
            var response = await Client.GetAsync($"{Client.BaseAddress}api/character{queryParams}");
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<PageDto<Character>>(await response.Content.ReadAsStringAsync()) : default(PageDto<Character>);

        }

        protected async Task<PageDto<T>?> GetUrl<T>(string url)
        {
            var response = await Client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<PageDto<T>>(response);
        }
        protected async Task<T>? GetSingleUrl<T>(string url)
        {
            var response = await Client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(response);
        }

        protected async Task<PageDto<T>?> GetSimplePages<T>(string path, int page = 0)
        {
            var response = await Client.GetStringAsync(Client.BaseAddress + $"/api/{path}/?page={page}");

            return JsonConvert.DeserializeObject<PageDto<T>>(response);

        }
        protected async Task<T> Get<T>(string path)
        {
            var response = await Client.GetAsync(path);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()) : default(T);
        }
        protected async Task<PageDto<T>> GetPage<T>(string path)
        {
            var response = await Client.GetAsync(path);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<PageDto<T>>(await response.Content.ReadAsStringAsync()) : default(PageDto<T>);
        }
        protected async Task<IEnumerable<T>> GetPages<T>(string url)
        {
            var result = new List<T>();
            var nextPage = -1;

            do
            {
                var dto = await Get<PageDto<T>>(nextPage == -1 ? url : $"{url}{(url.Contains("?") ? "&" : "?")}page={nextPage}");
                if (dto == null)
                    break;
                result.AddRange(dto.Results);

                nextPage = dto.Info.Next.GetNextPageNumber();
            }
            while (nextPage != -1);

            return result;
        }
    }
}
