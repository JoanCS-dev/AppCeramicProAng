using System.Data;
using AppCeramicProAng.Models.DTO;
using Microsoft.Data.SqlClient;

namespace AppCeramicProAng.Models.DAO
{
    public class WebProfileDAO : ConnectionDB
    {
        readonly string SP1 = "CPE_WEB_SPProfile";
        public ResponseDTO DropList()
        {
            ResponseDTO res = new ResponseDTO();
            try
            {
                var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
                cmd.Parameters.AddRange(Prm("SELECT_DROPLIST"));
                using var dr = cmd.ExecuteReader();
                res.HasRows(dr);
                List<object> lst = new List<object>();
                while (dr.Read())
                {
                    lst.Add(new
                    {
                        id = Convert.ToInt64(dr["ProfileID"]),
                        text = dr["ProDescription"].ToString()
                    });
                }
                if (lst.Count > 0)
                {
                    res.Data = lst;
                }
                else
                {
                    res.Data = null;
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
        private SqlParameter[] Prm(string CCase)
        {
            return new SqlParameter[]
            {
        new SqlParameter("@Case", CCase)
            };
        }
    }
}