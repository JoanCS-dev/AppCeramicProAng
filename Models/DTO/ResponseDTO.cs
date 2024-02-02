using Microsoft.Data.SqlClient;

namespace AppCeramicProAng.Models.DTO
{
    public class ResponseDTO<T> : ParmsVM where T : new()
  {
    public T? Data { get; set; }
    public ResponseDTO() : this("error", false, "", "Ocurrió un error interno por favor inténtalo más tarde.", new T()) { }
    public ResponseDTO(string type, bool ok, string title, string message, T data) : base(type, ok, title, message, new { })
    {
      Data = data;
    }
  }

  public class ResponseDTO : ParmsVM
  {

    public object? Data { get; set; }
    public ResponseDTO() : this("error", false, "", "Ocurrió un error interno por favor inténtalo más tarde.", new { }) { }
    public ResponseDTO(string type, bool ok, string title, string message, object data) : base(type, ok, title, message, new { })
    {
      Data = data;
    }
  }

  public class ParmsVM
  {
    public string Type { get; set; } = "";
    public bool Ok { get; set; } = false;
    public string Title { get; set; } = "Ocurrió un error interno por favor inténtalo más tarde.";
    public string Message { get; set; } = "";
    public object? Info { get; set; } = new { };

    public ParmsVM() : this("error", false, "", "Ocurrió un error interno por favor inténtalo más tarde.", new { }) { }
    public ParmsVM(string type, bool ok, string title, string message, object info)
    {
      Type = type;
      Ok = ok;
      Title = title;
      Message = message;
      Info = info;
    }

    public void Error(string message)
    {
      Ok = false;
      Message = message;
      Type = "error";
      Info = null;
    }

    public void Warning(string message)
    {
      Ok = false;
      Message = message;
      Type = "warning";
      Info = null;
    }

    public void Information(string message)
    {
      Ok = false;
      Message = message;
      Type = "information";
      Info = null;
    }

    public void Error(Exception ex)
    {
      Ok = false;
      Message = "Ocurrió un error interno, por favor contactar a sistemas. detalle: " + ex.Message;
      Type = "error";
      Info = null;
    }

    public void Success(string message)
    {
      Ok = true;
      Message = message;
      Type = "success";
    }
    public void Success()
    {
      Ok = true;
      Message = "Proceso realizado con éxito.";
      Type = "success";
    }

    private void Find()
    {
      Ok = true;
      Message = "Información encontrada";
      Type = "success";
      Info = null;
    }

    private void NotFind()
    {
      Ok = false;
      Message = "Información no encontrada";
      Type = "information";
      Info = null;
    }

    public void HasRows(SqlDataReader dr)
    {
      if (dr.HasRows) Find();
      else NotFind();
    }

    public void DBCatchResponseInOneLine(SqlDataReader dr)
    {
      if (dr != null)
      {
        string? _message = dr["Message"].ToString();
        bool _ok = Convert.ToBoolean(dr["Ok"]);

        if (_message != null)
        {
          if (_ok)
          {
            Success(_message);
          }
          else
          {
            Error(_message);
          }
        }
        else
        {
          throw new Exception();
        }

      }
      else
      {
        throw new Exception();
      }
    }
  }
}