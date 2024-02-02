using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using AppCeramicProAng.Models.DAO;
using AppCeramicProAng.Models.DTO;

namespace AppCeramicProAng.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class WebAccountController : ControllerBase
    {
        readonly WebAccountDAO accountService = new();
        readonly WebPeopleDAO peopleService = new();
        readonly IConfiguration configuration;

        public WebAccountController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Auth")]
        public ResponseDTO Auth([FromBody] WebAccountDTO account)
        {
            ResponseDTO response = new();
            try
            {
                ResponseDTO<WebAccountDTO> _res = accountService.Auth(account);
                if (_res.Ok && _res.Data != null)
                {
                    WebJwtDTO jwt = configuration.GetSection("Jwt").Get<WebJwtDTO>();
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("AccountID", _res.Data.AccountID.ToString()),
                        new Claim("AcUser", _res.Data.AcUser ?? "")
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var sigin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                      jwt.Issuer,
                      jwt.Audience,
                      claims,
                      expires: DateTime.Now.AddMinutes(60),
                      signingCredentials: sigin);

                    string _fullname_ = "";


                    if (_res.Data.PeopleVM != null)
                    {
                        _fullname_ = _res.Data.PeopleVM.FullName();
                    }


                    WebAccountAuthDTO accountAuthVM = new()
                    {
                        StrToken = new JwtSecurityTokenHandler().WriteToken(token),
                        FullName = _fullname_,
                        StrCode = _res.Data.Token ?? ""
                    };

                    response.Success("Acceso concedido");
                    response.Data = accountAuthVM;
                }
                else
                {
                    response.Ok = _res.Ok;
                    response.Type = _res.Type;
                    response.Message = _res.Message;
                    response.Title = _res.Title;
                    response.Data = null;
                    response.Info = null;
                }
            }
            catch (Exception ex)
            {
                response.Error(ex);
                response.Data = null;
                response.Info = null;
            }
            return response;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ResponseDTO Add([FromBody] WebAccountDTO account)
        {
            ResponseDTO response = new();
            try
            {
                if (account.PeopleVM != null)
                {
                    response = peopleService.Add(account.PeopleVM);

                    if (response.Ok)
                    {
                        if (account != null)
                        {
                            account.PeopleID = Convert.ToInt64(response.Info);
                            response = accountService.Add(account);
                            if (response.Ok)
                            {
                                account.AccountID = Convert.ToInt64(response.Info);
                                accountService.Actived(account);
                            }
                        }
                        else
                        {
                            response.Error("Ocurrió un error, por favor inténtalo más tarde, object [account] is null");
                        }
                    }
                }
                else
                {
                    response.Error("Ocurrió un error, por favor inténtalo más tarde, object [PeopleVM] is null");
                }
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }
        [HttpPost]
        [Route("Deactivate")]
        [Authorize]
        public ResponseDTO Deactivate([FromBody] WebAccountDTO account)
        {
            ResponseDTO response = new();
            try
            {
                response = accountService.Deactivate(account);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }
        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ResponseDTO Delete([FromBody] WebAccountDTO account)
        {
            ResponseDTO response = new();
            try
            {
                response = accountService.Delete(account);
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }
        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ResponseDTO Update([FromBody] WebAccountDTO account)
        {
            ResponseDTO response = new();
            try
            {
                if (account.PeopleVM != null)
                {
                    response = peopleService.Update(account.PeopleVM);

                    if (response.Ok)
                    {
                        if (account != null)
                        {
                            account.PeopleID = Convert.ToInt64(response.Info);
                            response = accountService.Update(account);
                            if (response.Ok)
                            {
                                account.AccountID = Convert.ToInt64(response.Info);
                            }
                        }
                        else
                        {
                            response.Error("Ocurrió un error, por favor inténtalo más tarde, object [account] is null");
                        }
                    }
                }
                else
                {
                    response.Error("Ocurrió un error, por favor inténtalo más tarde, object [PeopleVM] is null");
                }
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("Lst")]
        [Authorize]
        public ResponseDTO<List<WebAccountLstDTO>> Lst()
        {
            return accountService.Lst();
        }
    }
}