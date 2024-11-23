using Data.Context;
using Data.Entities.Addresses;
using Data.Entities.Enums;
using Data.Entities.Operation.Sorting;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repositories.Repositories.Operation
{
    public class SecondSegmentRepository : ISecondSegmentRepository
    {
        private readonly AppDbContext context;

        public SecondSegmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddSecondSegmentAsync(SecondSegment input)
        {
            await context.Set<SecondSegment>().AddAsync(input);
        }

        public void DeleteSecondSegment(SecondSegment input)
        {
            context.Set<SecondSegment>().Remove(input);
        }

        public async Task<SecondSegment> FindSecondSegmentByCodeAsync(string code)
        {
           return await context.Set<SecondSegment>().FindAsync(code);
        }

        public async Task<IEnumerable<SecondSegment>> FindSecondSegmentByEnablingAsync(StatusEnum status)
        {
            return await context.Set<SecondSegment>()
                .Where(x=>x.Status==status).ToListAsync();
        }

        public async Task<IEnumerable<SecondSegment>> FindSecondSegmentByFinalOrganizationNameAsync(string name)
        {
            return await context.Set<SecondSegment>().Include(x=>x.FirstSegment)
                .Where(x => x.FirstSegment.FinalOrganizationName == name).ToListAsync();
        }

        public async Task<IEnumerable<SecondSegment>> GetAllSecondSegmentAsync()
        {
             return await context.Set<SecondSegment>().ToListAsync();
        }

        public async Task<IEnumerable<SecondSegment>> GetAllSecondSegmentByBranchNameAsync(string name)
        {
            return await context.Set<SecondSegment>().Include(x => x.Branch)
                .Where(x => x.Branch.Name == name).ToListAsync();
        }

        public async Task<SecondSegment> GetSecondSegmentByAreaAsync(Area area)
        {
            return await context.Set<SecondSegment>()
                .Include(x => x.Area)
               .FirstOrDefaultAsync(x => x.AreaId == area.Id);
        }

        public void UpdateSecondSegment(SecondSegment input)
        {
            context.Set<SecondSegment>().Update(input);
        }
    }
}
