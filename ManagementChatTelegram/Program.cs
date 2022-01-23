using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using ManagementChatTelegram.Features.Handler;
using ManagementChatTelegram.Services;

namespace ManagementChatTelegram
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            ConfigureServices(serviceProvider);
            serviceProvider.AddSingleton<Management, Management>().BuildServiceProvider().GetService<Management>().Start();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<RepositoryService>();
            services.AddSingleton(new LiteDatabase("Data/hs.db"));
            services.AddSingleton(new TelegramService("5249711440:AAHZif9kfC5EKnW1OrONRniJya0OXxUa8vo", -1001540886471));
            services.AddMediatR(typeof(SendTextPublicationHandel));
            services.AddMediatR(typeof(GetListLeaderBoardHandler));
            services.AddMediatR(typeof(CreateImageHandler));
            services.AddMediatR(typeof(SendImagePublicationHandler));
        }
    }
}
