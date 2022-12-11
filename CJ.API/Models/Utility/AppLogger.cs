using System;
using System.IO;


namespace CJ.API.Models.Utility
{
    public class AppLogger
    {
        public static void PrintException(Exception ex, string message)
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyLogFile.txt");
            using (StreamWriter writer = new StreamWriter(destPath, append: true))
            {


                writer.WriteLine("------------------------------------------------");
                writer.WriteLine("Exception Time: " + DateTime.Now);
                writer.WriteLine("Other Info: " + message);
                writer.WriteLine("Exception: " + ex);
            }
        }
        public static void PrintException(Exception ex)
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyLogFile.txt");
            using (StreamWriter writer = new StreamWriter(destPath, append: true))
            {
                writer.WriteLine("------------------------------------------------");
                writer.WriteLine("Exception Time: " + DateTime.Now);
                writer.WriteLine("Exception: " + ex);
            }
        }
        public static void PrintException(string message)
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyLogFile.txt");
            using (StreamWriter writer = new StreamWriter(destPath, append: true))
            {
                writer.WriteLine("------------------------------------------------");
                writer.WriteLine(message);
            }
        }
    }
}