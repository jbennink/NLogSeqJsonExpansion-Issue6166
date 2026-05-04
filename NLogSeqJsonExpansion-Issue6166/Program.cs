using NLog;
using NLog.Web;

namespace NLogSeqJsonExpansion_Issue6166;

internal class Program
{
    static void Main(string[] args)
    {
        var logger = LogManager.Setup()
            .LoadConfigurationFromAppSettings()
            .GetCurrentClassLogger();

        logger.Properties["EXTRA"] = "ExtraValue";

        var o = new SomeObject
        {
            Id = 1,
            Name = "Test"
        };
        logger.Log(LogLevel.Info, "SomeObject contents: {@Object}",o);


        LogManager.Shutdown(); // Ensure logs are flushed
    }
}

internal class SomeObject
{
    public int Id { get; set; }
    public string Name { get; set; }
}