using Data.Entities.Operation.Sorting;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface ISecondSegmentRepository
    {
        Task AddSecondSegmentAsync(SecondSegment input);
        void UpdateSecondSegment(SecondSegment input);
        void DeleteSecondSegment(SecondSegment input);
        Task<SecondSegment> FindSecondSegmentByIdAsync(int id);
        Task<DataPage<SecondSegment>> GetAllSecondSegmentsAsync(SearchCriteria input);
    }
}
