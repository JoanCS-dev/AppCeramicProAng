using Microsoft.Data.SqlClient;
using AppCeramicProAng.Models.DTO;
using System.Data;
using AppCeramicProAng.Tools;

namespace AppCeramicProAng.Models.DAO
{
    public class WebAccountDAO : ConnectionDB
  {
    readonly string SP1 = "CPE_WEB_SPAccount";
    public ResponseDTO<WebAccountDTO> Auth(WebAccountDTO account)
    {
      ResponseDTO<WebAccountDTO> response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(account, "SELECT_AUTH"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {

          WebAccountDTO accountVM = new()
          {
            AccountID = Convert.ToInt64(dr["AccountID"]),
            AcUser = dr["AcUser"].ToString(),
            AcPhoneNumber = dr["AcPhoneNumber"].ToString(),
            Token = dr["Token"].ToString(),
            PeopleVM = new()
            {
              PeFirstName = dr["PeFirstName"].ToString(),
              PeLastName = dr["PeLastName"].ToString()
            }
          };

          if (accountVM.AcUser == account.AcUser)
          {
            response.Success("Acceso concedido");
            response.Data = accountVM;
          }
          else
          {
            response.Error("El usuario y/o la contraseña son incorrectos.");
            response.Data = null;
          }
        }
        else
        {
          response.Error("El usuario y/o la contraseña son incorrectos.");
          response.Data = null;
        }

      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    public ResponseDTO Add(WebAccountDTO account)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(account, "INSERT"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          response.DBCatchResponseInOneLine(dr);
          response.Info = Convert.ToInt64(dr["IdAux"]);
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      if (response.Ok)
      {
        account.AccountID = Convert.ToInt64(response.Info);
        var _res = UpdateToken(account);
        if (!_res.Ok)
        {
          response.Error(_res.Message);
          response.Data = null;
        }
      }
      return response;
    }
    public ResponseDTO Update(WebAccountDTO account)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(account, "UPDATE"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          response.DBCatchResponseInOneLine(dr);
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    public ResponseDTO UpdateToken(WebAccountDTO account)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(account, "UPDATE_TOKEN"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          response.DBCatchResponseInOneLine(dr);
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    public ResponseDTO Actived(WebAccountDTO account)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(account, "ACTIVE_DATA"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          response.DBCatchResponseInOneLine(dr);
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    public ResponseDTO Deactivate(WebAccountDTO account)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(account, "DEACTIVATE"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          response.DBCatchResponseInOneLine(dr);
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    public ResponseDTO Delete(WebAccountDTO account)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(account, "DELETE"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          response.DBCatchResponseInOneLine(dr);
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    public ResponseDTO<List<WebAccountLstDTO>> Lst()
    {
      ResponseDTO<List<WebAccountLstDTO>> response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms("SELECT"));
        using var dr = cmd.ExecuteReader();
        response.HasRows(dr);
        while (dr.Read())
        {
          WebAccountLstDTO accountVM = new()
          {
            AccountID = Convert.ToInt64(dr["AccountID"]),
            AcUser = dr["AcUser"].ToString(),
            AcEmailAddress = dr["AcEmailAddress"].ToString(),
            AcPhoneNumber = dr["AcPhoneNumber"].ToString(),
            Token = dr["Token"].ToString(),
            AcStatus = dr["AcStatus"].ToString(),
            AcVerifyEmail = Convert.ToBoolean(dr["AcVerifyEmail"].ToString()),
            PeopleVM = new()
            {
              PeFirstName = dr["PeFirstName"].ToString(),
              PeLastName = dr["PeLastName"].ToString()
            },
            ProfileVM = new() {
              ProfileID = Convert.ToInt64(dr["ProfileID"]),
              ProDescription = dr["ProDescription"].ToString()
            }
          };

          response.Data?.Add(accountVM);
        }
        if (!response.Ok)
        {
          response.Data = null;
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    private static SqlParameter[] Prms(WebAccountDTO account, string CCase)
    {
      string _pss = account.AcPassword ?? "";
      return new SqlParameter[] {
        new SqlParameter("@AccountID", account.AccountID),
        new SqlParameter("@AcUser", account.AcUser),
        new SqlParameter("@AcPassword", new Encrypt().Sha256Hash(_pss)),
        new SqlParameter("@AcPhoneNumber", account.AcPhoneNumber),
        new SqlParameter("@Token",  new Encrypt().Sha256Hash(account.AccountID.ToString())),
        new SqlParameter("@ProfileID", account.ProfileID),
        new SqlParameter("@PeopleID", account.PeopleID),
        new SqlParameter("@Case", CCase),
      };
    }
    private static SqlParameter[] Prms(string CCase)
    {
      return new SqlParameter[] {
        new SqlParameter("@Case", CCase),
      };
    }
  }
}