using System;
using System.IO;

namespace CRM
{
    public class Logger
  {
      //loglama 
      private static string logPath = @"C:\Users\Kamran\Documents\Visual Studio 2017\Projects\CRM\CRM\Logs";

      public static void Write(string type, string text)
      {
          
          if (!File.Exists(Path.Combine(logPath,DateTime.Now.ToString("dd.MM.yyyy")+".txt")))
          {
              FileStream f = System.IO.File.Create(Path.Combine(logPath, DateTime.Now.ToString("dd.MM.yyyy") + ".txt"));
              f.Close();
            //  File.Create(Path.Combine(logPath, DateTime.Now.ToString("dd.MM.yyyy") + ".txt"));
          }


            using (StreamWriter sw = new StreamWriter(Path.Combine(logPath, DateTime.Now.ToString("dd.MM.yyyy") + ".txt"), append: true))
            {
                sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " " + type + " : " + text);
            }
      }
  }
}
