using System.Data;
using AppCeramicProAng.Models.DTO;
using Microsoft.Data.SqlClient;

namespace AppCeramicProAng.Models.DAO
{
    public class WebEmailDAO : ConnectionDB
  {
    readonly string SP1 = "CPE_WEB_SPEmails";
    public ResponseDTO Add(WebEmailDTO item)
    {
      ResponseDTO res = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prm(item, "INSERT"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          res.DBCatchResponseInOneLine(dr);
        }
      }
      catch (Exception ex)
      {
        res.Error(ex);
      }
      finally
      {
        CloseConnection();
      }
      return res;
    }
    public ResponseDTO Update(WebEmailDTO item)
    {
      ResponseDTO res = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prm(item, "UPDATE"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          res.DBCatchResponseInOneLine(dr);
        }
      }
      catch (Exception ex)
      {
        res.Error(ex);
      }
      finally
      {
        CloseConnection();
      }
      return res;
    }
    public ResponseDTO<List<WebEmailDTO>> Lst()
    {
      ResponseDTO<List<WebEmailDTO>> res = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prm(new WebEmailDTO(), "SELECT"));
        using var dr = cmd.ExecuteReader();
        res.HasRows(dr);
        while (dr.Read())
        {
          res.Data?.Add(new WebEmailDTO
          {
            EmailID = Convert.ToInt64(dr["EmailID"]),
            EmSubject = dr["EmSubject"].ToString(),
            EmBody = dr["EmBody"].ToString(),
            EmEmail = dr["EmEmail"].ToString(),
            EmEnviarSts = Convert.ToBoolean(dr["EmEnviarSts"]),
            EmEnviarEmail = dr["EmEnviarEmail"].ToString(),
            EmEmailCC = dr["EmEmailCC"].ToString(),
            EmPassword = dr["EmPassword"].ToString()
          });
        }

      }
      catch (Exception ex)
      {
        res.Error(ex);
      }
      finally
      {
        CloseConnection();
      }
      return res;
    }
    public ResponseDTO<WebEmailDTO> Lst(WebEmailDTO item)
    {
      ResponseDTO<WebEmailDTO> res = new ();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prm(item, "SELECT_BY_ID"));
        using var dr = cmd.ExecuteReader();

        res.HasRows(dr);
        while (dr.Read())
        {
          res.Data = new WebEmailDTO
          {
            EmailID = Convert.ToInt64(dr["EmailID"]),
            EmSubject = dr["EmSubject"].ToString(),
            EmBody = dr["EmBody"].ToString(),
            EmEmail = dr["EmEmail"].ToString(),
            EmEnviarSts = Convert.ToBoolean(dr["EmEnviarSts"]),
            EmEnviarEmail = dr["EmEnviarEmail"].ToString(),
            EmEmailCC = dr["EmEmailCC"].ToString(),
            EmPassword = dr["EmPassword"].ToString()
          };
        }

      }
      catch (Exception ex)
      {
        res.Error(ex);
      }
      finally
      {
        CloseConnection();
      }
      return res;
    }
    private static SqlParameter[] Prm(WebEmailDTO item, string CCase)
    {
      return new SqlParameter[] {
        new SqlParameter("@EmailID", item.EmailID),
        new SqlParameter("@EmSubject", item.EmSubject),
        new SqlParameter("@EmBody", item.EmBody),
        new SqlParameter("@EmEmail", item.EmEmail),
        new SqlParameter("@EmPassword", item.EmPassword),
        new SqlParameter("@EmEnviarSts", item.EmEnviarSts),
        new SqlParameter("@EmEnviarEmail", item.EmEnviarEmail),
        new SqlParameter("@EmEmailCC", item.EmEmailCC),
        new SqlParameter("@Case", CCase)
      };
    }
  }
}