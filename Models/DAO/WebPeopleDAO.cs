using System.Data;
using AppCeramicProAng.Models.DTO;
using Microsoft.Data.SqlClient;

namespace AppCeramicProAng.Models.DAO
{
    public class WebPeopleDAO : ConnectionDB
  {
    readonly string SP1 = "CPE_WEB_SPPeople";
    public ResponseDTO Add(WebPeopleDTO people)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(people, "INSERT"));
        using var dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          response.DBCatchResponseInOneLine(dr);
          response.Info = Convert.ToInt64(dr["IdAux"]);
        }
      }
      catch (Exception ex) { response.Error(ex); response.Data = null; }
      finally { CloseConnection(); }
      return response;
    }
    public ResponseDTO Update(WebPeopleDTO people)
    {
      ResponseDTO response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(people, "UPDATE"));
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
    public ResponseDTO<List<WebPeopleLstDTO>> Lst(WebPeopleDTO people)
    {
      ResponseDTO<List<WebPeopleLstDTO>> response = new();
      try
      {
        var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddRange(Prms(people, "SELECT_PK"));
        using var dr = cmd.ExecuteReader();
        response.HasRows(dr);
        while (dr.Read())
        {
          WebPeopleLstDTO accountVM = new()
          {
            PeopleID = Convert.ToInt64(dr["PeopleID"]),
            PeFirstName = dr["PeFirstName"].ToString(),
            PeLastName = dr["PeLastName"].ToString(),
            PeDateOfBirth = dr["PeDateOfBirth"].ToString(),
            PeStatus = Convert.ToBoolean(dr["PeStatus"]),
            PeRDate = dr["PeRDate"].ToString(),
            PeStreet = dr["PeStreet"].ToString(),
            PeOutsideCode = dr["PeOutsideCode"].ToString(),
            PeInsideCode = dr["PeInsideCode"].ToString(),
            SettlementID = Convert.ToInt64(dr["SettlementID"])
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
    private static SqlParameter[] Prms(WebPeopleDTO people, string CCase)
    {
      return new SqlParameter[] {
        new SqlParameter("@PeopleID", people.PeopleID),
        new SqlParameter("@PeFirstName", people.PeFirstName),
        new SqlParameter("@PeLastName", people.PeLastName),
        new SqlParameter("@Case", CCase),
      };
    }
  }
}