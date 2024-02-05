using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Webase.Telegram.Bot.Abstract;
using WEBASE.TelegramBot;

namespace WEBASE.Telegram.Bot.Services;
public class ReceiverService : ReceiverServiceBase<UpdateHandler>
{
    public ReceiverService(
        ITelegramBotClient botClient,
        UpdateHandler updateHandler,
        ILogger<ReceiverServiceBase<UpdateHandler>> logger)
        : base(botClient, updateHandler, logger)
    {
    }
}
