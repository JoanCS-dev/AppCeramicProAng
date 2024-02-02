using Microsoft.Data.SqlClient;
using System.Data;

namespace AppCeramicProAng.Models.DAO
{
  public class ConnectionDB
  {
    readonly SqlConnection cnx;
    public ConnectionDB()
    {
      cnx = new SqlConnection("Data Source=metalmarketdb.database.windows.net;Initial Catalog=MetalMarket;UID=userdbMetalMarket;PWD=@21Azure21; Persist Security Info=True; Connection Timeout=0");
    }
    protected SqlConnection OpenConnection()
    {
      if (cnx != null)
      {
        if (cnx.State == ConnectionState.Closed)
        {
          cnx.Open();
        }
      }
      else
      {
        throw new Exception("Parameters [cnx] is null.");
      }
      return cnx;
    }
    protected void CloseConnection()
    {
      if (cnx != null)
      {
        if (cnx.State == ConnectionState.Open)
        {
          cnx.Close();
        }
      }
      else
      {
        throw new Exception("Parameters [cnx] is null.");
      }
    }
  }
}