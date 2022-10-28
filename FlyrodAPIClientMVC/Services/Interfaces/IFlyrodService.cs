using FlyrodAPIClientMVC.Models;

namespace FlyrodAPIClientMVC.Services.Interfaces
{
    public interface IFlyrodService
    {
        Task<IEnumerable<Flyrod>> FindAll();

        Task<Flyrod> FindOne(int id);
    }
}