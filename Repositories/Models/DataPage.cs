namespace Repositories.Models
{
    public class DataPage<T>
    {
        public DataPage(int pageIndex, int pageSize, int count, IQueryable<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IQueryable<T> Data { get; set; }
    }
}
