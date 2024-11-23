using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class ScanRepository : IScanRepository
    {
        private readonly AppDbContext context;

        public ScanRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddScanAsync(Scan input)
        {
            await context.Set<Scan>().AddAsync(input);
        }

        public async Task<Scan> FindScanAsync(int code)
        {
            return await context.Set<Scan>().FindAsync(code);
        }

        public async Task<IEnumerable<Scan>> GetAllScansAsync()
        {
            return await context.Set<Scan>().ToListAsync();
        }

        public void UpdateScan(Scan input)
        {
             context.Set<Scan>().Update(input);
        }
    }
}
