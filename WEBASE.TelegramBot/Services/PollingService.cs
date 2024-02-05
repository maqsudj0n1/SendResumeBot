using Microsoft.Extensions.Logging;
using Webase.Telegram.Bot.Abstract;

namespace WEBASE.Telegram.Bot.Services;

public class PollingService : PollingServiceBase<ReceiverService>
{
    public PollingService(IServiceProvider serviceProvider, ILogger<PollingService> logger)
        : base(serviceProvider, logger)
    {
    }
}
