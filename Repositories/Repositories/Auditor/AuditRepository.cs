using Data.Context;
using Data.Entities.Helper;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Auditor
{
    public class AuditRepository : IAuditRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManager;

        public AuditRepository(AppDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        private async Task<Guid> Int2Guid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
        private async Task<int> Guid2Int(Guid value)
        {
            byte[] b = value.ToByteArray();
            int bint = BitConverter.ToInt32(b, 0);
            return bint;
        }
        private async Task<Guid> String2Guid(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), "The input string cannot be null or empty.");

            // Convert the string to bytes
            byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes(value);

            // Ensure the byte array is exactly 16 bytes (required for a Guid)
            byte[] guidBytes = new byte[16];
            Array.Copy(stringBytes, guidBytes, Math.Min(stringBytes.Length, 16));

            return new Guid(guidBytes);
        }
        private async Task<string> Guid2String(Guid guid)
        {
            // Convert the Guid to bytes
            byte[] guidBytes = guid.ToByteArray();

            // Convert the bytes back to a string
            return System.Text.Encoding.UTF8.GetString(guidBytes).TrimEnd('\0');
        }
        public async Task<LogData> GetLog(long Id)
        {
            var result = await context.Set<LogData>().Include(x => x.User).FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }

        public async Task<DataPage<LogData>> GetLogs(Guid userId, string tableName, ActionEnum action, string q, int? pageIndex, int? pageSize)
        {
            Expression<Func<LogData, bool>> condition = null;
            pageIndex -= 1;
            condition = x => (x.LogObjectProperties.Contains(q) || string.IsNullOrEmpty(q)) &&
                             (x.UserId == userId || userId == Guid.Empty) &&
                             (x.TableName == tableName || string.IsNullOrEmpty(tableName)) &&
                             (x.Action == action || action == 0);

            var data = await context.Logs.Include(x => x.User)
                .Where(condition)
                .OrderByDescending(x => x.Date)
                .Skip(pageIndex.Value * pageSize.Value)
                .Take(pageSize.Value)
                .ToListAsync();

            var totalCount = await context.Logs.Where(condition).CountAsync();

            DataPage<LogData> result = new DataPage<LogData>(pageIndex.Value, pageSize.Value, totalCount, data.AsQueryable());

            return result;
        }

        public async Task<DataPage<LogData>> GetLogs(int? pageIndex, int? pageSize)
        {
            pageIndex -= 1;
            var data = context.Logs.Include(x => x.User)
                .OrderByDescending(x => x.Date)
                .Skip(pageIndex.Value * pageSize.Value)
                .Take(pageSize.Value)
                .ToList();

            var totalCount = context.Logs.Count();

            DataPage<LogData> result = new DataPage<LogData>(pageIndex.Value, pageSize.Value, totalCount, data.AsQueryable());

            return result;
        }

        public async Task SaveLog(Guid orderNumber, object? entityId, string tableName, ActionEnum action, Guid userId)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var order = await context.Set<Order>().FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);

            Guid? entityGuid = entityId switch
            {
                Guid guid => guid,
                int intId => await Int2Guid(intId),
                string strId => await String2Guid(strId),
                null => null,
                _ => throw new ArgumentException("Invalid entityId type", nameof(entityId))
            };
            LogData log = new LogData()
            {
                Date = DateTime.Now,
                WaybillNumber = order.WaybillNumber,
                EntityId = entityGuid,
                Action = action,
                UserId = userId,
                TableName = tableName,
                LogObjectProperties = string.Format(
                        "User {0} has done action ({1}) on table {2}, Object {3} On Order ({4})",
                        user.UserName, action, tableName, entityGuid, order.WaybillNumber),
                LogObjectProperties_Ar = string.Format(
                        "قام المستخدم {0} بعمل {1} على الصفحة {2} و السجل {3} على الاوردر ({4})",
                        user.UserName, action, tableName, entityGuid, order.WaybillNumber)
            };
            await context.Logs.AddAsync(log);
        }
        public async Task SaveLog(Guid orderNumber, object? entityId, string tableName, ActionEnum action, string clientCode)
        {
            var user = await context.Set<Client>().FirstOrDefaultAsync(x => x.ClientCode == clientCode);
            var order = await context.Set<Order>().FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);

            Guid? entityGuid = entityId switch
            {
                Guid guid => guid,
                int intId => await Int2Guid(intId),
                string strId => await String2Guid(strId),
                null => null,
                _ => throw new ArgumentException("Invalid entityId type", nameof(entityId))
            };
            LogData log = new LogData()
            {
                Date = DateTime.Now,
                WaybillNumber = order.WaybillNumber,
                EntityId = entityGuid,
                Action = action,
                UserId = await String2Guid(clientCode),
                TableName = tableName,
                LogObjectProperties = string.Format(
                        "User {0} has done action ({1}) on table {2}, Object {3} On Order ({4})",
                        user.ClientName, action, tableName, entityGuid, order.WaybillNumber),
                LogObjectProperties_Ar = string.Format(
                        "قام المستخدم {0} بعمل {1} على الصفحة {2} و السجل {3} على الاوردر ({4})",
                        user.ClientName, action, tableName, entityGuid, order.WaybillNumber)
            };
            await context.Logs.AddAsync(log);
        }
    }

}
