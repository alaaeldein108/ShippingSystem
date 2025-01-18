using Data.Entities.Addresses;

namespace Repositories.Interfaces.Addresses
{
    public interface ICityRepository
    {
        Task<City> GetCityById(string code);
        Task<IQueryable<City>> GetAllCitiesAsync();

    }
}
