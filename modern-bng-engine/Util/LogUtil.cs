using System.IO;
using System.Threading.Tasks;

namespace ModernBng.Util
{
    internal static class LogUtil
    {
        const string _logFile = "ModernBngEngine.log";

        internal static async Task Log(string msg)
        {
            using (var writer = File.AppendText(_logFile))
            {
                await writer.WriteLineAsync(msg);
            }
        }
    }
}
