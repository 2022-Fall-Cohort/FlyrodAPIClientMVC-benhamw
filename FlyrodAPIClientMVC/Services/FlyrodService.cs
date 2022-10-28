using FlyrodAPIClientMVC.Helpers;
using FlyrodAPIClientMVC.Models;
using FlyrodAPIClientMVC.Services.Interfaces;

namespace FlyrodAPIClientMVC.Services
{
    public class FlyrodService : IFlyrodService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Flyrod/";

        public FlyrodService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Flyrod>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<Flyrod>>();

            return response;
        }

        public async Task<Flyrod> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Flyrod>();

            var flyrod = new Flyrod(response.Id, response.Model, response.LengthFeet, response.Sections, response.LineWeight, response.YearMade, response.Type, response.Construction, response.RodImage, response.MakerId);
          

            return flyrod;
        }
    }
}