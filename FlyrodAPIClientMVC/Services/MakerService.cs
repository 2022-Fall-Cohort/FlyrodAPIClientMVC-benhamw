using FlyrodAPIClientMVC.Helpers;
using FlyrodAPIClientMVC.Models;
using FlyrodAPIClientMVC.Services.Interfaces;

namespace FlyrodAPIClientMVC.Services
{
    public class MakerService : IMakerService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Maker/";

        public MakerService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Maker>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<Maker>>();

            return response;
        }

        public async Task<Maker> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Maker>();

            var maker = new Maker(response.Id, response.Name, response.YearFounded, response.Type);


            return maker;
        }
    }
}