using System.Data;
using AppCeramicProAng.Models.DTO;
using Microsoft.Data.SqlClient;

namespace AppCeramicProAng.Models.DAO
{
    public class WebSupportDAO : ConnectionDB
    {

        readonly string SP1 = "CPE_WEB_SPSupport";
        public ResponseDTO Add(WebSupportDTO support)
        {
            ResponseDTO response = new();
            try
            {
                var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddRange(Prms(support));
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

        private static SqlParameter[] Prms(WebSupportDTO support)
        {
            return new SqlParameter[] {
        new SqlParameter("@fullname", support.fullname),
        new SqlParameter("@email", support.email),
        new SqlParameter("@problem", support.problem)
      };
        }
    }
}