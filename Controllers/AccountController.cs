using AppCeramicProAng.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppCeramicProAng.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public ICollection<AccountDTO> ToList()
        {
            return new List<AccountDTO>
            {
                new AccountDTO(){AccountName = "Joan", Password="soiny09yds08y8tb8ys"},
                new AccountDTO(){AccountName = "Josue", Password="kohoinyuynoiny08y9y"}
            };
        }
    }
}