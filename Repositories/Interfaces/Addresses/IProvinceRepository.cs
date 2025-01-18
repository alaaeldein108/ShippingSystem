using Data.Entities.Addresses;

namespace Repositories.Interfaces.Addresses
{
    public interface IProvinceRepository
    {
        Task<Province> GetProvinceById(string code);
        Task<IEnumerable<Province>> GetAllProvincesAsync();
    }
}
