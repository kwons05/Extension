using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Utility
{
    public enum LogLevel
    {
        Fatal,
        Error,
        Warn,
        Info,
        Debug
    }
    /// <summary>
    /// ログ
    /// </summary>
    public static class Logger1
    {
        private static TextWriter Writer;
        /// <summary>
        /// ログファイルのオープン
        /// </summary>
        /// <param name="filePath"></param>
        public static void Open(string filePath)
        {
            // ファイルストリーム
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Unicode)
            {
                AutoFlush = true,
            };
            //スレッドセーフ
            Writer = TextWriter.Synchronized(sw);
        }
        /// <summary>
        /// ログファイルのクローズ
        /// </summary>
        public static void Close()
        {
            if (Writer != null)
            {
                Writer.Flush();
                Writer.Close();
            }
        }
        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="level"></param>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        public static void Write(LogLevel level, string message, Exception ex)
        {
            Write(level, string.Format("Message:{0} \r\nException:{1}", message, ex != null ? ex.ToString() : "null"));
        }
        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="level"></param>
        /// <param name="text"></param>
        public static void Write(LogLevel level, string text)
        {
            if (Writer != null)
            {
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                switch (level)
                {
                    case LogLevel.Debug:
                        Writer.WriteLine(string.Format("[{0}] [DEBUG] {1}", dateTime, text));
                        break;
                    case LogLevel.Info:
                        Writer.WriteLine(string.Format("[{0}] [INFO] {1}", dateTime, text));
                        break;
                    case LogLevel.Warn:
                        Writer.WriteLine(string.Format("[{0}] [WARN] {1}", dateTime, text));
                        break;
                    case LogLevel.Error:
                        Writer.WriteLine(string.Format("[{0}] [ERROR] {1}", dateTime, text));
                        break;
                    case LogLevel.Fatal:
                        Writer.WriteLine(string.Format("[{0}] [FATAL] {1}", dateTime, text));
                        break;
                    default:
                        Writer.WriteLine(string.Format("[{0}] [UnKnown] {1}", dateTime, text));
                        break;
                }
            }
        }
        public static void NewLine()
        {
            if (Writer != null)
            {
                Writer.WriteLine("--------------------------------------------------------------------------------");
            }
        }
    }
}
