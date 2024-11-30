using Data.Entities.Operation.COD_FOD_Adjustment;
using Data.Entities.Operation.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IFirstSegmentRepository
    {
        Task AddFirstSegmentAsync(FirstSegment input);
        void UpdateFirstSegment(FirstSegment input);
        void DeleteFirstSegment(FirstSegment input);
        Task<FirstSegment> FindFirstSegmentByIdAsync(int id);
        Task<IQueryable<FirstSegment>> GetAllFirstSegmentsAsync();
    }
}
