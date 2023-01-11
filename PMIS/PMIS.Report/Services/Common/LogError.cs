using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;

namespace PMIS.Services.Common
{
    public interface ILogError
    {
        void Error(HttpServerUtilityBase _env, Exception ex);
    }

    public class LogError : ILogError
    {
        //private readonly HttpServerUtilityBase _env;

        //public LogError(HttpServerUtilityBase env)
        //{
        //    this._env = env;
        //}
        public void Error(HttpServerUtilityBase _env, Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();
            var fileName = frame.GetFileName();

            var path = Path.Combine(_env.MapPath("/Log"), "log.txt");
            StreamWriter sw = File.AppendText(path);
            var msg = DateTime.Now + "\n" + fileName + ":" + line + "\nMessage: " + ex.Message +
                "\nInner Exception: " + ex.InnerException + "\n";
            sw.WriteLine(msg);
            sw.Flush();
            sw.Close();
        }
    }
}