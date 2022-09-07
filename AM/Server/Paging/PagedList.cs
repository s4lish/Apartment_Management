namespace AM.Server.Paging
{
    public class PagedList<T> : List<T>
    {
        public static async Task<Pagination<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize).ToListAsync();

            var paginationInfo = new Pagination<T>() { Data = items.ToList(), TotalCount = count };

            return paginationInfo;
        }
    }
}
