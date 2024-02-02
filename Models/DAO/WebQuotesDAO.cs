using System.Data;
using AppCeramicProAng.Models.DTO;
using Microsoft.Data.SqlClient;

namespace AppCeramicProAng.Models.DAO
{
    public class WebQuotesDAO : ConnectionDB
    {
        readonly string SP1 = "CPE_WEB_SPQuotes";
        public ResponseDTO Cancel(WebQuotesDTO quotes)
        {
            ResponseDTO response = new();
            try
            {
                var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddRange(Prms(quotes, "CANCEL"));
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
        public ResponseDTO Accept(WebQuotesDTO quotes)
        {
            ResponseDTO response = new();
            try
            {
                var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddRange(Prms(quotes, "ACEPTAR"));
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
        public ResponseDTO List()
        {
            ResponseDTO response = new();
            try
            {
                var cmd = new SqlCommand(SP1, OpenConnection()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddRange(Prms("SELECT_ALL"));
                using var dr = cmd.ExecuteReader();
                response.HasRows(dr);
                List<object> lst = new();
                while (dr.Read())
                {
                    lst.Add(new
                    {
                        QuotesID = Convert.ToInt64(dr["QuotesID"]),
                        FullName = dr["FullName"].ToString(),
                        QuotesDate = dr["QuotesDate"].ToString(),
                        QuotesHour = dr["QuotesHour"].ToString(),
                        ServiceDesc = dr["ServiceDesc"].ToString(),
                        ColorName = dr["ColorName"].ToString(),
                        QuotesSTS = dr["QuotesSTS"].ToString(),
                        VehicleModelID = Convert.ToInt64(dr["VehicleModelID"]),
                        VehicleModelName = dr["VehicleModelName"].ToString(),
                        VehicleBrandID = Convert.ToInt64(dr["VehicleBrandID"]),
                        VehicleBrandName = dr["VehicleBrandName"].ToString(),
                        ServicePrice = Convert.ToDecimal(dr["ServicePrice"]),
                        FHRegister = dr["FHRegister"].ToString()
                    });
                }

                if (response.Ok)
                {
                    response.Data = lst;
                }
                else
                {
                    response.Data = null;
                }
            }
            catch (Exception ex) { response.Error(ex); response.Data = null; }
            finally { CloseConnection(); }
            return response;
        }
        private static SqlParameter[] Prms(WebQuotesDTO quotes, string CCase)
        {
            return new SqlParameter[] {
        new SqlParameter("@QuotesID", quotes.QuotesID),
        new SqlParameter("@ServicePriceID", quotes.ServicePriceID),
        new SqlParameter("@ColorID", quotes.ColorID),
        new SqlParameter("@QuotesSTS", quotes.QuotesSTS),
        new SqlParameter("@QuoteHoursID", quotes.QuoteHoursID),
        new SqlParameter("@AccountID", quotes.AccountID),
        new SqlParameter("@VehicleModelID", quotes.VehicleModelID),
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