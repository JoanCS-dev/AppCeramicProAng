using System.Security.Claims;
using AppCeramicProAng.Models.DAO;
using AppCeramicProAng.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AppCeramicProAng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebQuotesController : ControllerBase
    {
        readonly WebQuotesDAO quotesService = new();
        [HttpPost]
        [Route("Cancel")]
        [Authorize]
        public ResponseDTO Cancel([FromBody] WebQuotesDTO quotes)
        {
            ResponseDTO res = new();
            // Recuperar los claims del Token
            try
            {
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    if (!identity.Claims.Any())
                    {
                        res.Error("El token ingresado no es valido");
                        res.Data = null;
                    }
                    else
                    {
                        var _AccountID_IDEN = identity.Claims.FirstOrDefault(x => x.Type == "AccountID");
                        long AccountID = Convert.ToInt64(_AccountID_IDEN == null ? 0 : _AccountID_IDEN.Value);
                        quotes.AccountID = AccountID;
                        res = quotesService.Cancel(quotes);
                    }
                }
            }
            catch (Exception ex)
            {
                res.Error(ex);
                res.Data = null;
            }
            return res;
        }

        [HttpPost]
        [Route("Accept")]
        [Authorize]
        public ResponseDTO Accept([FromBody] WebQuotesDTO quotes)
        {
            ResponseDTO res = new();
            // Recuperar los claims del Token
            try
            {
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    if (!identity.Claims.Any())
                    {
                        res.Error("El token ingresado no es valido");
                        res.Data = null;
                    }
                    else
                    {
                        var _AccountID_IDEN = identity.Claims.FirstOrDefault(x => x.Type == "AccountID");
                        long AccountID = Convert.ToInt64(_AccountID_IDEN == null ? 0 : _AccountID_IDEN.Value);
                        quotes.AccountID = AccountID;
                        res = quotesService.Accept(quotes);
                    }
                }
            }
            catch (Exception ex)
            {
                res.Error(ex);
                res.Data = null;
            }
            return res;
        }

        [HttpPost]
        [Route("Lst")]
        [Authorize]
        public ResponseDTO Lst()
        {
            ResponseDTO res = new();
            // Recuperar los claims del Token
            try
            {
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    if (identity.Claims.Any())
                    {
                        /*
                        var _AccountID_IDEN = identity.Claims.FirstOrDefault(x => x.Type == "AccountID");
                        long AccountID = Convert.ToInt64(_AccountID_IDEN == null ? 0 : _AccountID_IDEN.Value);
                        quotes.AccountID = AccountID;
                        */
                        res = quotesService.List();
                    }
                    else
                    {
                        res.Error("El token ingresado no es valido");
                        res.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                res.Error(ex);
                res.Data = null;
            }
            return res;
        }
    }
}