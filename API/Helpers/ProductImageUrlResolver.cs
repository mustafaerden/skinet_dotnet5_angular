using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
  // Burada product image i full url ile dondurmek istiyoruz. (http::localhost:5000/image-url gibi)
  public class ProductImageUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
  {
    private readonly IConfiguration _config;
    public ProductImageUrlResolver(IConfiguration config)
    {
      _config = config;
    }

    public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
    {
      if (!string.IsNullOrEmpty(source.PictureUrl))
      {
        // appsettings.development.json dosyasinda ApiUrl olarak http://localhost:5000/ belirttik.
        return _config["ApiUrl"] + source.PictureUrl;
      }

      return null;
    }
  }
}