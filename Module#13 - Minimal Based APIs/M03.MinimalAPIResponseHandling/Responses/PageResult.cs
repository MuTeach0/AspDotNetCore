namespace M03.MinimalAPIResponseHandling.Responses;

public class PageResult<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    private PageResult() { }

    public static PageResult<T> Create(IEnumerable<T> items, int totalCount, int currentPage, int pageSize) =>
        new()
        {
            Items = items,
            TotalCount = totalCount,
            CurrentPage = currentPage,
            PageSize = pageSize
        };
}