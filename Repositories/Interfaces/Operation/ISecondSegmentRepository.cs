using Data.Entities.Addresses;
using Data.Entities.Enums;
using Data.Entities.Operation;
using Data.Entities.Operation.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface ISecondSegmentRepository
    {
        Task AddSecondSegmentAsync(SecondSegment input);
        void UpdateSecondSegment(SecondSegment input);
        void DeleteSecondSegment(SecondSegment input);
        Task<IEnumerable<SecondSegment>> GetAllSecondSegmentByBranchNameAsync(string name);
        Task<SecondSegment> FindSecondSegmentByCodeAsync(string code);
        Task<IEnumerable<SecondSegment>> FindSecondSegmentByFinalOrganizationNameAsync(string name);
        Task<IEnumerable<SecondSegment>> FindSecondSegmentByEnablingAsync(StatusEnum status);
        Task<IEnumerable<SecondSegment>> GetAllSecondSegmentAsync();
        Task<SecondSegment> GetSecondSegmentByAreaAsync(Area area);
    }
}
