using Data.Entities.Helper;
using Repositories.Models;

namespace Repositories.Interfaces.Auditor
{
    public interface IAuditRepository
    {
        #region Log
        Task SaveLog(Guid orderNumber, object? entityId, string tableName, ActionEnum action, Guid userId);
        Task SaveLog(Guid orderNumber, object? entityId, string tableName, ActionEnum action, string clientCode);
        Task<DataPage<LogData>> GetLogs(Guid userId, string tableName, ActionEnum action, string q, int? pageIndex, int? pageSize);
        Task<LogData> GetLog(long Id);
        Task<DataPage<LogData>> GetLogs(int? pageIndex, int? pageSize);
        #endregion
    }
}
