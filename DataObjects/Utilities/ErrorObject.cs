// Decompiled with JetBrains decompiler
// Type: ErrorObject
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

using System.Web;

public class ErrorObject
{
  private string _error_type = "Error";
  private string _error_no = "5002";
  private string _error_code = "000002";
  private string _error_message = string.Empty;
  private string _error_source = string.Empty;
  private string _error_in_procedure = "-";
  private string _error_stacktrace = "-";
  private string _error_ref = string.Empty;
  private string _remit_user_cd;
  private string _parent_agent_cd;

  public string Remit_user_cd
  {
    get
    {
      return this._remit_user_cd;
    }
    set
    {
      this._remit_user_cd = value;
    }
  }

  public string Parent_agent_cd
  {
    get
    {
      return this._parent_agent_cd;
    }
    set
    {
      this._parent_agent_cd = value;
    }
  }

  public string EType
  {
    get
    {
      return this._error_type;
    }
  }

  public string ENo
  {
    get
    {
      return this._error_no;
    }
  }

  public string ECode
  {
    get
    {
      return this._error_code;
    }
    set
    {
      this._error_code = value;
    }
  }

  public string EMessage
  {
    get
    {
      return this._error_message;
    }
    set
    {
      this._error_message = value;
    }
  }

  public string ESource
  {
    get
    {
      return this._error_source;
    }
    set
    {
      this._error_source = value;
    }
  }

  public string EProcedure
  {
    get
    {
      return this._error_in_procedure;
    }
    set
    {
      this._error_in_procedure = value;
    }
  }

  public string EStacktrace
  {
    get
    {
      return this._error_stacktrace;
    }
    set
    {
      this._error_stacktrace = value;
    }
  }

  public string Eref
  {
    get
    {
      return this._error_ref;
    }
    set
    {
      this._error_ref = value;
    }
  }

  public ErrorObject()
  {
    if (HttpContext.Current.Session["userId"] != null)
    {
      this._remit_user_cd = HttpContext.Current.Session["userId"].ToString();
      this._parent_agent_cd = HttpContext.Current.Session["PACode"].ToString();
    }
    else
    {
      this._remit_user_cd = "annonymous";
      this._parent_agent_cd = "00001";
    }
  }

  public ErrorObject(ErrorObject.ErrorType et)
  {
    switch (et)
    {
      case ErrorObject.ErrorType.SPError:
        this._error_type = "SP Generated Error";
        this._error_no = "50003";
        break;
      case ErrorObject.ErrorType.SelectError:
        this._error_type = "Select Generated Error";
        this._error_no = "50004";
        break;
      case ErrorObject.ErrorType.InsertError:
        this._error_type = "Insert Generated Error";
        this._error_no = "50005";
        break;
      case ErrorObject.ErrorType.UpdateError:
        this._error_type = "Update Generated Error";
        this._error_no = "50006";
        break;
    }
    if (HttpContext.Current.Session["userId"] != null)
    {
      this._remit_user_cd = HttpContext.Current.Session["userId"].ToString();
      this._parent_agent_cd = HttpContext.Current.Session["PACode"].ToString();
    }
    else
    {
      this._remit_user_cd = "annonymous";
      this._parent_agent_cd = "00001";
    }
  }

  public enum ErrorType
  {
    SPError = 1,
    SelectError = 2,
    InsertError = 3,
    UpdateError = 4,
  }
}
