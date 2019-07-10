using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ModernBng.Util
{
    // This class is an alternative to Microsoft.VisualStudio.Profiler.dll, which hard-locks game on track load screen
    internal class TimerUtil : IDisposable
    {
        Stopwatch _sw;
        List<long> _times;

        internal TimerUtil()
        {
            _sw = Stopwatch.StartNew();
            _times = new List<long>();
        }

        void RecordSection()
        {
            _times.Add(_sw.ElapsedMilliseconds);
            _sw.Restart();
        }

        public async void Dispose()
        {
            RecordSection();
            _sw.Stop();
            await LogUtil.Log($"---{DateTime.Now}---");
            await LogUtil.Log(ToString());
        }

        public override string ToString()
        {
            var head = "UtilPerformanceTimer section times: {0}";
            return string.Format(head, string.Join(",", _times));
        }
    }
}
