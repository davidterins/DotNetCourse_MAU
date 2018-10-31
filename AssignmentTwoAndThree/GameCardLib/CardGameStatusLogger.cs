using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GameCardLib
{
  public class CardGameStatusLogger
  {
    public ObservableCollection<LogStatus> Logs { get; set; }

    public CardGameStatusLogger()
    {
      Logs = new ObservableCollection<LogStatus>();
    }

    public void NewStatus(string logStatement, LogColor color)
    {
      Logs.Add(new LogStatus(logStatement, color));
      RemoveOnMaxLimitExceded();
    }


    void RemoveOnMaxLimitExceded()
    {
      if (Logs.Count > 7)
      {
        Logs.RemoveAt(0);
      }
    }


  }

  public enum LogColor { Gray, Green, Yellow, Red }
  public class LogStatus
  {
    public string Statement { get; private set; }
    public LogColor Type { get; private set; }

    public LogStatus(string statement, LogColor logColor)
    {
      Statement = statement;
      Type = logColor;
    }
  }


}

