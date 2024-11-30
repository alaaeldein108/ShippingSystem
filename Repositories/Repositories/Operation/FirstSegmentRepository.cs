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

        public async Task<FirstSegment> FindFirstSegmentByIdAsync(int id)
        {
            return await context.Set<FirstSegment>()
                            .Include(x => x.Area).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<FirstSegment>> GetAllFirstSegmentsAsync()
        {
            return context.Set<FirstSegment>()
                            .Include(x => x.Area);
        }

        public void UpdateFirstSegment(FirstSegment input)
        {
            context.Set<FirstSegment>().Update(input);
        }
       
    }
}
