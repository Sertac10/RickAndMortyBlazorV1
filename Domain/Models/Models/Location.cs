namespace RickAndMortyBlazorV1.Models
{
    public class Location
    {
        public Location(int id = 0, string name = "", string type = "", string dimension = "", IEnumerable<string> residents = null,
            string url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            Type = type;
            Dimension = dimension;
            Residents = residents;
            Url = url;
            Created = created;
        }
        public int Id { get; }
        public string Name { get; }
        public string Type { get; }
        public string Dimension { get; }
        public IEnumerable<string> Residents { get; }
        public string Url { get; }
        public DateTime? Created { get; }
    }
}
