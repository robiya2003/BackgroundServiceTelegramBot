
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace Farqiyoq.servicess
{
    public class SardorService : BackgroundService
    {
        private readonly TelegramBotClient _client;
        private readonly IUpdateHandler _updateHandler;
        public SardorService(TelegramBotClient client,IUpdateHandler updateHandler)

        {
            _client = client;
            _updateHandler = updateHandler;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _client.StartReceiving(
                updateHandler:_updateHandler.HandleUpdateAsync,
                pollingErrorHandler:_updateHandler.HandlePollingErrorAsync,
                receiverOptions:new ReceiverOptions()
                {
                    ThrowPendingUpdates = true
                },
                cancellationToken:stoppingToken);
        }
        
    }
}
