namespace MarkdownReader.Services
{
    public class GtiHubService : IFileReader
    {
        private readonly HttpClient _Client;
        public GtiHubService(HttpClient aClient)
        {
            _Client = aClient;
        }

        public async Task<string> ReadFile(string filePath)
        {
            Console.WriteLine("Start reading file.");
            var response = await _Client.GetAsync(filePath);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }
    }
}
