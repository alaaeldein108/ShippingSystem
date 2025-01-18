using Data.Entities.Operation.Sorting;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IFirstSegmentRepository
    {
        Task AddFirstSegmentAsync(FirstSegment input);
        void UpdateFirstSegment(FirstSegment input);
        void DeleteFirstSegment(FirstSegment input);
        Task<FirstSegment> FindFirstSegmentByIdAsync(int id);
        Task<DataPage<FirstSegment>> GetAllFirstSegmentsAsync(SearchCriteria input);
    }
}
