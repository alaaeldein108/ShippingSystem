using Data.Context;
using Data.Entities.Operation.COD_FOD_Adjustment;
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
    public class FirstSegmentRepository : IFirstSegmentRepository
    {
        private readonly AppDbContext context;

        public FirstSegmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddFirstSegmentAsync(FirstSegment input)
        {
            await context.Set<FirstSegment>().AddAsync(input);
        }

        public void DeleteFirstSegment(FirstSegment input)
        {
            context.Set<FirstSegment>().Remove(input);
        }

        public async Task<IEnumerable<FirstSegment>> FindFirstSegmentByCodeAsync(int code)
        {
            return await context.Set<FirstSegment>()
                .Include(x=>x.Area)
                .Where(x=>x.FirstSegmentCode==code)
                .ToListAsync();
        }

        public async Task<IEnumerable<FirstSegment>> FindFirstSegmentByFinalOrganizationNameAsync(string name)
        {
            return await context.Set<FirstSegment>()
               .Include(x => x.Area)
               .Where(x => x.FinalOrganizationName == name)
               .ToListAsync();
        }

        public async Task<IEnumerable<FirstSegment>> FindFirstSegmentNameAsync(string name)
        {
            return await context.Set<FirstSegment>()
               .Include(x => x.Area)
               .Where(x => x.FirstSegmentName == name)
               .ToListAsync();
        }

        public async Task<IEnumerable<FirstSegment>> GetAllFirstSegmentsAsync()
        {
            return await context.Set<FirstSegment>()
                .Include(x => x.Area).ToListAsync();
        }

        public void UpdateFirstSegment(FirstSegment input)
        {
            context.Set<FirstSegment>().Update(input);
        }
    }
}
