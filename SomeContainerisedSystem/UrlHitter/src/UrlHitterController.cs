using Microsoft.AspNetCore.Mvc;

namespace UrlHitter.Api;

[ApiController]
public class UrlHitterController(HttpClient httpClient) : ControllerBase
{
    private readonly HttpClient _httpClient = httpClient;

    [HttpPost]
    [Route("try-url")]
    [Route("/")]
    public async Task<IActionResult> TryUrl([FromBody] UrlProvided url)
    {
        var response = await _httpClient.GetAsync(url.Url);
        var result = await response.Content.ReadAsStringAsync();
        return Ok($"The response code was {(int)response.StatusCode}. With content: \n {result}");
    }

    [HttpGet]
    [Route("test")]
    [Route("/")]
    public IActionResult Test()
    {
        return Ok("Url hitter worked!");
    }

    [HttpGet]
    [Route("hit-volume/{volumePath}")]
    public IActionResult HitVolume(string volumePath)
    {
        var volumeLocation = Path.Combine("..", "..", volumePath);
        //var result = Directory.GetDirectories(volumeLocation);
        //Console.WriteLine("The directories are below");
        //foreach (var file in result) { Console.WriteLine(file); };
        var stream = new FileStream(Path.Combine(volumeLocation, "test.txt"), FileMode.OpenOrCreate);
        using (var writer = new StreamWriter(stream))
        {
            writer.WriteLine("oranges are not the only fruit");
        }

        return Ok();
    }
}
