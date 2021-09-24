using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  /**
      Api da hic olmayan bir url e request yapildigi zaman sadece bos 404 not found donuyordu. Onu mesajla birlikte dondurmek istiyoruz.
  */

  [ApiController]
  [Route("errors/{code}")]
  // Bu controller i ekledikten sonra swagger server error veriyodu. Onu duzeltmek icin sunu ekledik;
  [ApiExplorerSettings(IgnoreApi = true)]
  public class ErrorController : ControllerBase
  {
    public IActionResult Error(int code)
    {
      return new ObjectResult(new ApiResponse(code));
    }
  }
}