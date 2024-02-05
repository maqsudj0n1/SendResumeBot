using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SendResumeBot.BizLogicLayer.Services;
using SendResumeBot.DataLayer;
using SendResumeBot.DataLayer.EfClasses;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace WEBASE.TelegramBot;

public class UpdateHandler : IUpdateHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<UpdateHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private string Comment;
    public UpdateHandler(ITelegramBotClient botClient, IUserService userService, ILogger<UpdateHandler> logger, IUnitOfWork unitOfWork)
    {
        _botClient = botClient;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _userService = userService;
    }
    public async Task HandleUpdateAsync(ITelegramBotClient _client, Update update, CancellationToken cancellationToken)
    {

        if (update.Message == null && update.CallbackQuery == null) return;
        Parallel.Invoke(async () =>
        {
            string cmd = update?.Message?.Text;
            var user = _unitOfWork.Context.Users.FirstOrDefault(x => x.ChatId == update.Message.Chat.Id);
            if (user == null)
            {
                _userService.Create(new CreateUserDto()
                {
                    ChatId = update.Message.Chat.Id,
                    Step = -1,
                    UserName = update.Message.Chat.Username,
                    StateId = 1
                });
                user = _unitOfWork.Context.Users.FirstOrDefault(x => x.ChatId == update.Message.Chat.Id);
            }

            if ((user?.Step == 0 || user?.Step == 1) && update.Message.Document != null)
                cmd = "/receiveresume";

            await (cmd switch
            {
                "/start" => StartHandler(_client, update, user),
                "/receiveresume" => ReceiveAndSendResume(_client, update, user, cancellationToken),
                _ => StartHandler(_client, update, user), // Default case
            });
        });
    }
  
    private async Task StartHandler(ITelegramBotClient _client, Update update, SendResumeBot.DataLayer.EfClasses.User user)
    {
        var startMenuButtons = _unitOfWork.Context.Buttons.Include(x=> x.Translates).Where(x => x.OrderCode == "send_resume").ToList();

        var text = "Ассалому алайкум!\r\nАгар таълим ёки тиббиёт соҳасида ислоҳотларга хисса қўшиб, Лойиҳа офисларида ишлаш ниятида бўлсангиз шу ерга иккита файлни юборинг:\r\n1. Фамилия_cv.pdf (doc, docx)\r\n2. Фамилия_таклифлар.pdf (doc, docx)";
          await   _client.SendTextMessageAsync(user.ChatId, text);
        if(user.Step == -1)
        {
            user.Step++;
            _unitOfWork.Save();
        }
       
    }
    private async Task ReceiveAndSendResume(ITelegramBotClient _client, Update update, SendResumeBot.DataLayer.EfClasses.User user, CancellationToken cancellationToken)
    {
        string channelId = "-1002066560612"; // Replace with your channel ID

        // Forward the file to the channel
        await _client.ForwardMessageAsync(
            chatId: channelId,
            fromChatId: update.Message.Chat.Id,
            messageId: update.Message.MessageId
        );
        user.Step++;
        _unitOfWork.Save();
            await _client.SendTextMessageAsync(user.ChatId, "Muvoffaqiyatli yuborildi");
    }

    private Task UnknownUpdateHandlerAsync(Update update, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        _logger.LogInformation("HandleError: {ErrorMessage}", ErrorMessage);
        if (exception is RequestException)
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
    }

}
