using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ViServiceAdapter
{
    internal class AdapterService : BackgroundService
    {
        private readonly ILogger<AdapterService> _logger;

        public AdapterService(ILogger<AdapterService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(AdapterService)} started");
            await Task.Run(() => Action(cancellationToken), cancellationToken);
            _logger.LogInformation($"{nameof(AdapterService)} stopped");
        }

        public async Task Action(CancellationToken cancellationToken)
        {
            var startInfo = Program.Options.MakeProc();
            var p = Process.Start(startInfo);
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(10);
            }
            p.Kill();

        }
    }
}
