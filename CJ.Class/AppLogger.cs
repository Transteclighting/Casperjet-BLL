using System;
using System.Diagnostics;
using log4net;
using System.IO;
using System.Configuration;

namespace CJ.Class
{
	/// <summary>
	/// Summary description for AppLogger.
	/// </summary>
	public class AppLogger
	{
    static private bool m_bInit = false;
		public AppLogger()
		{

		}
    
    static private bool configLogger()
    {
      if (m_bInit == true)
      {
        return true;
      }

      String sBinDir = ConfigurationSettings.AppSettings["AppLog"];
     
      sBinDir = (sBinDir == null ? String.Empty : sBinDir.Trim() );

      if (Directory.Exists(sBinDir) == false)
      {
        return false;
      }

      string sConfigPath = String.Empty;
      try
      {
        sConfigPath = Path.Combine( sBinDir, "Log4Net.config");
      }
      catch(Exception ex)
      {
        Console.WriteLine( ex.Message );
        return false;
      }      

      if (File.Exists( sConfigPath ) == false )
      {
        return false;
      }
      FileInfo fi = new FileInfo(sConfigPath);

      try
      {
        log4net.Config.DOMConfigurator.Configure(fi);
      }
      catch(Exception ex)
      {
        Console.WriteLine( ex.Message );
        return false;        
      }

      m_bInit = true;
      return true;      

    }


    static public void LogFatal(object oLog)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Fatal(oLog);
    }
    static public void LogFatal(object oLog, System.Exception ex)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Fatal(oLog, ex);
    }

    static public void LogError(object oLog)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Error(oLog);
    }

    static public void LogError(object oLog, System.Exception ex)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Error(oLog, ex);
    }


    static public void LogWarning(object oLog)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Warn(oLog);
    }
    static public void LogWarning(object oLog, System.Exception ex)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Warn(oLog, ex);
    }

    static public void LogInfo(object oLog)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType  );
      log.Info(oLog);
    }
    static public void LogInfo(object oLog, System.Exception ex)
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Info(oLog, ex);
    }

    static public void LogDebug(object oLog )
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Debug(oLog);        
    }

    static public void LogDebug(object oLog, System.Exception ex )
    {
      bool bOk = configLogger();
      StackTrace st = new StackTrace();
      StackFrame sf = st.GetFrame(1);
      ILog log = LogManager.GetLogger(sf.GetMethod().DeclaringType);
      log.Debug(oLog, ex);
    }

	}
}
