using FlyrodAPIClientMVC.Models;

namespace FlyrodAPIClientMVC.Services.Interfaces
{
    public interface IMakerService
    {
        Task<IEnumerable<Maker>> FindAll();

        Task<Maker> FindOne(int id);
    }
}
