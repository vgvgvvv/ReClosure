using System.Diagnostics;
using System.Text;

namespace ReClosure;

public interface IDebug
{
    void Log(string msg);
    void Warning(string msg);
    void Error(string msg);
    void Assert(bool condition, string msg);
}

public class Debug
{
    public static Debug Default { get; } = new Debug();

    public static void SetDefault(IDebug debug)
    {
        Default._debug = debug;
    }
    
    private IDebug? _debug = null;
    
    
    public static void Log(string msg)
    {
        Default._debug?.Log(msg);
    }

    public static void Warning(string msg)
    {
        Default._debug?.Warning(msg);
    }

    public static void Error(string msg)
    {
        Default._debug?.Error(msg);
    }

    public static void Assert(bool condition, string msg)
    {
        Default._debug?.Assert(condition, msg);
    }
}