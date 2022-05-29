using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace WpfApp.Utility
{
    //public static class ThreadSafeControl
    //{
    //    public static void InvokeIfRequired<T>(this T c, Action<T> action) where T : Control
    //    {
    //        if (c.InvokeRequired)
    //        {
    //            c.Invoke(new Action(() => action(c)));
    //        }
    //        else
    //        {
    //            action(c);
    //        }
    //    }
    //}
    public static class WatchTime
    {
        private static object thisLock = new object();

        public static void StartEx(this Stopwatch sw)
        {
            //lock (thisLock)
            {
                sw.Reset();
                sw.Start();
            }
        }
        public static void StopEx(this Stopwatch sw, Action<long> write, ulong cnt)
        {
            //lock (thisLock)
            {
                sw.Stop();
            }
            write(sw.ElapsedMilliseconds);
        }

    }
}
