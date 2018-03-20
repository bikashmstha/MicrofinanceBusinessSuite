// Decompiled with JetBrains decompiler
// Type: MessageObject
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

public class MessageObject
{
  private int _OutResultCode = 0;
  private string _OutResultMessage = string.Empty;
  private bool _ExecuteSuccess = false;
  private object _Result = (object) null;

  public int OutResultCode
  {
    get
    {
      return this._OutResultCode;
    }
    set
    {
      this._OutResultCode = value;
    }
  }

  public string OutResultMessage
  {
    get
    {
      return this._OutResultMessage;
    }
    set
    {
      this._OutResultMessage = value;
    }
  }

  public bool ExecuteSuccess
  {
    get
    {
      return this._ExecuteSuccess;
    }
    set
    {
      this._ExecuteSuccess = value;
    }
  }

  public object Result
  {
    get
    {
      return this._Result;
    }
    set
    {
      this._Result = value;
    }
  }
}
