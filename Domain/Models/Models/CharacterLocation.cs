namespace RickAndMortyBlazorV1.Models
{
    public class CharacterLocation
    {
        public CharacterLocation(string name = "", string url = null)
        {
            Name = name;
            Url = url;
        }
        public string Name { get; }
        public string Url { get; }
    }
}
