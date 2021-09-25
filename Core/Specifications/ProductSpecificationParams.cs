namespace Core.Specifications
{
  public class ProductSpecificationParams
  {
    // En fazla 50 product dondurulecek.
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;

    // default olarak 5 product dondurulecek
    private int _pageSize = 5;
    public int PageSize
    {
      get => _pageSize;
      set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public string Sort { get; set; }
    private string _search;
    public string Search
    {
      get => _search;
      set => _search = value.ToLower();
    }
  }
}