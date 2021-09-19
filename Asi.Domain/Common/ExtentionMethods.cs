using System.Linq;

namespace Asi.Domain.Common
{
    public static class ExtentionMethods
    {

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, PaginationFilter pagination) where T : class
        {

            var count = source.Count();
            var items = source.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
            return new PagedList<T>(items, count, pagination.PageNumber, pagination.PageSize);
        }


    }
}
