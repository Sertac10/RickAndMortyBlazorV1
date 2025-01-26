using HtmlAgilityPack;

namespace Application.Helpers;
public static class GetRandomImage
{
    public static string uri { get; set; } = string.Empty;
    public static async Task<string> GetRandomGoogleImage(string searchTerm)
    {

        string query = Uri.EscapeDataString(searchTerm);
        string url = $"https://www.google.com/search?tbm=isch&q={query}";


        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

        var html = await httpClient.GetStringAsync(url);


        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);


        var imageNodes = htmlDocument.DocumentNode.SelectNodes("//img")
                            .Where(node => node.Attributes["src"] != null)
                            .Select(node => node.Attributes["src"].Value)
                            .ToList();


        var firstFiveImages = imageNodes.Take(5).ToList();

        if (firstFiveImages.Count > 0)
        {

            Random random = new Random();
            int randomIndex = random.Next(firstFiveImages.Count);
            return firstFiveImages[randomIndex];
        }
        else
        {
            return "No image found";
        }
    }


    static GetRandomImage()
    {
        uri = GetRandomGoogleImage("rick").GetAwaiter().GetResult();
    }
}
