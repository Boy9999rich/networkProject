using System.Text;
using System.Text.Json;

namespace _3._6Lesson__homework;

public class MusicCrudApIBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;
    public MusicCrudApIBroker()
    {
        _httpClient = new HttpClient();
        _baseUrl = "https://localhost:7110/api/music";
        //Add();
        //var bas = new Guid("47ab7584-7d60-4a75-b073-bc34b639895b");
        //Delete(bas);
        //var music = new Music()
        //{
        //    Id = new Guid("13bc2306-f6e5-46c4-b1bf-4dc218719345"),
        //    Name = "jalka harib",
        //    MB = 2.2,
        //    Description = "yovvoyi",
        //    QuantityLikes = 222,
        //    AuthorName = "Ahmadjon"
        //};
        //UpdateMusic(music);
        //GetAll();

        var life = new Guid("13bc2306-f6e5-46c4-b1bf-4dc218719345");
        getById(life);

    }
    public void GetAll()
    {
        var url = $"{_baseUrl}/GetAllMusic";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        string responseMessage = response.Content.ReadAsStringAsync().Result;



        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode is false)
        {
            throw new Exception("response qoniqarli emas");
        }

        JsonSerializerOptions option = new JsonSerializerOptions();
        option.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music[]>(responseMessage, option);
        foreach (var m in music)
        {
            Console.WriteLine(m);
        }
    }

    public void Add()
    {
        var url = $"{_baseUrl}/addMusic";
        var music = new Music()
        {
            Name = "never give up",
            AuthorName = "Asatbek",
            Description = "Axmadjon",
            MB = 5.5,
            QuantityLikes = 200,
        };

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PostAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);

    }

    public void Delete(Guid id)
    {
        //id = new Guid("47ab7584-7d60-4a75-b073-bc34b639895b");
        var url = $"{_baseUrl}/deleteMusic?id={id}";
        var response = _httpClient.DeleteAsync(url).Result;
        response.EnsureSuccessStatusCode();

    }

    public void UpdateMusic(Music music)
    {
        var url = $"{_baseUrl}/UpdateMusic";

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PutAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;    
        
    }




















    public void getById(Guid id)
    {
        var url = $"{_baseUrl}/getById?id={id}";
        var response = _httpClient.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);
    }

}
