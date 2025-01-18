using Data.Context;
using Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Addresses;
using Repositories.Models;
using System.Linq.Expressions;

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

        public async Task<ReceiverAddressBook> FindRecieverAddressBookByIdAsync(int id)
        {
            return await context.Set<ReceiverAddressBook>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<ReceiverAddressBook>> GetRecieverAddressesAsync(SearchCriteria input)
        {
            Expression<Func<ReceiverAddressBook, bool>> condition = null;
            condition = a => (a.Name.Contains(input.ReceiverName) || string.IsNullOrEmpty(input.ReceiverName)) &&
                            (a.Phone.Contains(input.PhoneNumber) || string.IsNullOrEmpty(input.PhoneNumber)) &&
                            (a.SecondPhone.Contains(input.SecondPhoneNumber) || string.IsNullOrEmpty(input.SecondPhoneNumber)) &&
                            (a.AreaId.Contains(input.AreaId) || string.IsNullOrEmpty(input.AreaId));

            var totalCount = await context.Set<ReceiverAddressBook>().Where(condition).CountAsync();

            var data = await context.Set<ReceiverAddressBook>().Include(x => x.Area)
                       .ThenInclude(x => x.City).ThenInclude(x => x.Province).Where(condition)
                       .Skip((input.PageIndex - 1) * input.PageSize)
                       .Take(input.PageSize)
                       .ToListAsync();

            return new DataPage<ReceiverAddressBook>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateRecieverAddress(ReceiverAddressBook input)
        {
            context.Set<ReceiverAddressBook>().Update(input);
        }
    }
}
