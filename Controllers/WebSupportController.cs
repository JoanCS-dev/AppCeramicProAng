using AppCeramicProAng.Models.DAO;
using AppCeramicProAng.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AppCeramicProAng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebSupportController : ControllerBase
    {
        readonly WebSupportDAO supportService = new();

        [HttpPost]
        [Route("Add")]
        public ResponseDTO Add(WebSupportDTO support) => supportService.Add(support);
    }
}