using RickAndMortyBlazorV1.Enums;

namespace RickAndMortyBlazorV1.Models
{
    public class Character
    {

        public Character(int id = 0, string name = "", CharacterStatus status = 0,
            string species = "", string type = "", CharacterGender gender = 0,
            CharacterLocation location = null, CharacterOrigin origin = null, string image = null,
            IEnumerable<string> episode = null, string url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            Location = location;
            Origin = origin;
            Image = image;
            Episode = episode;
            Url = url;
            Created = created;
        }
        public int Id { get; }
        public string Name { get; }
        public CharacterStatus Status { get; }
        public string Species { get; }
        public string Type { get; }
        public CharacterGender Gender { get; }
        public CharacterLocation Location { get; }
        public CharacterOrigin Origin { get; }
        public string Image { get; }
        public IEnumerable<string> Episode { get; }
        public string Url { get; }
        public DateTime? Created { get; }
    }
}
