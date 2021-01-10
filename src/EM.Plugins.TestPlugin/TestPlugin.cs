using System;
using System.Threading.Tasks;
using Impostor.Api.Plugins;
using Microsoft.Extensions.Logging;

namespace EM.Plugins.TestPlugin
{
    [ImpostorPlugin(package: "em.plugins.testplugin",
        name: "TestPlugin",
        author: "Cloudy",
        version: "1.0")]
    public class TestPlugin : PluginBase
    {
        private readonly ILogger<TestPlugin> _logger;

        public TestPlugin(ILogger<TestPlugin> logger)
        {
            _logger = logger;
        }

        public override ValueTask EnableAsync()
        {
            _logger.LogInformation("Example is being enabled.");
            return default;
        }

        public override ValueTask DisableAsync()
        {
            _logger.LogInformation("Example is being disabled.");
            return default;
        }
    }
}
