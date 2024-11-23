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
    public class RecieverAddressBookRepository : IRecieverAddressBookRepository
    {
        private readonly AppDbContext context;

        public RecieverAddressBookRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddRecieverAddressAsync(ReceiverAddressBook input)
        {
            await context.Set<ReceiverAddressBook>().AddAsync(input);
        }

        public void DeleteRecieverAddress(ReceiverAddressBook input)
        {
             context.Set<ReceiverAddressBook>().Remove(input);
        }

        public async Task<IEnumerable<ReceiverAddressBook>> FindSenderAddressesByClientCodeAsync(string clientId)
        {
            return await context.Set<ReceiverAddressBook>()
                .Where(x=>x.ClientId==clientId).ToListAsync();
        }

        public void UpdateRecieverAddress(ReceiverAddressBook input)
        {
            context.Set<ReceiverAddressBook>().Remove(input);
        }
    }
}
