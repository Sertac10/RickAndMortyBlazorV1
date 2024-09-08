namespace RickAndMortyBlazorV1.Dto
{
    public class PageDto<T>
    {
        public PageInfoDto Info { get; set; } = null!;
        public List<T> Results { get; set; } = null!;
    }
}
