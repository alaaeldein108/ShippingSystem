using Data.Context;
using Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Addresses;
using Repositories.Models;
using System.Linq.Expressions;

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

        public async Task<SenderAddressBook> FindSenderAddressBookByIdAsync(int id)
        {
            return await context.Set<SenderAddressBook>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<SenderAddressBook>> GetSenderAddressesAsync(SearchCriteria input)
        {
            Expression<Func<SenderAddressBook, bool>> condition = null;
            condition = a => (a.Name.Contains(input.SenderName) || string.IsNullOrEmpty(input.SenderName)) &&
                            (a.Phone.Contains(input.PhoneNumber) || string.IsNullOrEmpty(input.PhoneNumber)) &&
                            (a.SecondPhone.Contains(input.SecondPhoneNumber) || string.IsNullOrEmpty(input.SecondPhoneNumber)) &&
                            (a.AreaId.Contains(input.AreaId) || string.IsNullOrEmpty(input.AreaId));

            var totalCount = await context.Set<SenderAddressBook>().Where(condition).CountAsync();

            var data = await context.Set<SenderAddressBook>()
                            .Include(x => x.Area).ThenInclude(x => x.City)
                            .ThenInclude(x => x.Province).Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<SenderAddressBook>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());

        }

        public void UpdateSenderAddress(SenderAddressBook input)
        {
            context.Set<SenderAddressBook>().Update(input);

        }
    }
}
