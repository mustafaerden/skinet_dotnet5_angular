using System.Collections.Generic;

namespace API.Errors
{
  // Validation Errorlari Controller daki [ApiController] tagindan gelir. Onu Startup.cs de ApiBehaviorOptions ile override ettik ve orada bu ApiValidationResponse i dondurduk!! ORaya bak.
  public class ApiValidationErrorResponse : ApiResponse
  {
    public ApiValidationErrorResponse() : base(400)
    {
    }

    public IEnumerable<string> Errors { get; set; }
  }
}