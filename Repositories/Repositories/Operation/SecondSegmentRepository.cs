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

        public async Task<SecondSegment> FindSecondSegmentByIdAsync(string id)
        {
           return await context.Set<SecondSegment>().FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<IQueryable<SecondSegment>> GetAllSecondSegmentsAsync()
        {
           return  context.Set<SecondSegment>().Include(x=>x.Area).Include(x=>x.Branch);
        }

        public void UpdateSecondSegment(SecondSegment input)
        {
            context.Set<SecondSegment>().Update(input);
        }
    }
}
