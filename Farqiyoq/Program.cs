
using Farqiyoq.Handler;
using Farqiyoq.servicess;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace Farqiyoq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHostedService<SardorService>();

            builder.Services.AddSingleton(new TelegramBotClient("6406750559:AAFoJbQbMTSYAzMQzcAphTNA5F7Kf7CG-GY"));
            builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
