namespace RickAndMortyBlazorV1.Models
{
    public class CharacterOrigin
    {
        public CharacterOrigin(string name = "", string url = null)
        {
            Name = name;
            Url = url;
        }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
