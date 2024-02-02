using AppCeramicProAng.Models.DAO;
using AppCeramicProAng.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AppCeramicProAng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebEmailController : ControllerBase
    {
        readonly WebEmailDAO emailService = new();

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ResponseDTO Add(WebEmailDTO item) => emailService.Add(item);

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ResponseDTO Update(WebEmailDTO item) => emailService.Update(item);

        [HttpPost]
        [Route("Lst")]
        [Authorize]
        public ResponseDTO<List<WebEmailDTO>> Lst() => emailService.Lst();

    }
}