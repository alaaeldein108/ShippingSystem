using Data.Context;
using Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Addresses
{
    public class SenderAddressBookRepository : ISenderAddressBookRepository
    {
        private readonly AppDbContext context;

        public SenderAddressBookRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddSenderAddressAsync(SenderAddressBook input)
        {
            await context.Set<SenderAddressBook>().AddAsync(input);
        }

        public void DeleteSenderAddress(SenderAddressBook input)
        {
            context.Set<SenderAddressBook>().Remove(input);
        }
        public async Task<IEnumerable<SenderAddressBook>> FindSenderAddressesByClientCodeAsync(string clientId)
        {
            return await context.Set<SenderAddressBook>()
                .Where(x=>x.ClientId== clientId).ToListAsync();
        }

        public void UpdateSenderAddress(SenderAddressBook input)
        {
            context.Set<SenderAddressBook>().Update(input);

        }
    }
}
