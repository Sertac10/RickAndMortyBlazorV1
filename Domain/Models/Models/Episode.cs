using System.Text.Json.Serialization;

namespace RickAndMortyBlazorV1.Models
{
    public class Episode
    {
        public Episode(int id = 0, string name = "", string? airDate = null,
            string episodeCode = "", IEnumerable<string> characters = null,
            string url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            AirDate = airDate;
            EpisodeCode = episodeCode;
            Characters = characters;
            Url = url;
            Created = created;
        }
        public int Id { get; }
        public string Name { get; }
        //public DateTime? AirDate { get; }
        [JsonPropertyName("Air_date")]
        public string? AirDate { get; }
        public string EpisodeCode { get; }
        public IEnumerable<string> Characters { get; }
        public string Url { get; }
        public DateTime? Created { get; }
    }
}
