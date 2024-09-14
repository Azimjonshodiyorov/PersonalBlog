namespace Blog.Core.Common;

public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    
    public PagedResult(List<T> items, int totalRecords, int pageNumber, int pageSize)
    {
        Items = items;
        TotalRecords = totalRecords;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
    }

    public static PagedResult<T> Paginate(IQueryable<T> query, int pageNumber, int pageSize)
    {
        int totalRecords = query.Count();
        var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        
        return new PagedResult<T>(items, totalRecords, pageNumber, pageSize);
    }
}