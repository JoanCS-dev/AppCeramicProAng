using AppCeramicProAng.Models.DAO;
using AppCeramicProAng.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AppCeramicProAng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebProfileController : ControllerBase
    {
        readonly WebProfileDAO profileService = new();
        [HttpPost]
        [Route("DropList")]
        [Authorize]
        public ResponseDTO DropList() => profileService.DropList();

    }
}