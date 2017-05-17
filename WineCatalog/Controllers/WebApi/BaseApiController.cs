using System.Web.Http;

namespace WineCatalog.Controllers.WebApi
{
    [Authorize]
    public class BaseApiController : ApiController
    {
    }
}
