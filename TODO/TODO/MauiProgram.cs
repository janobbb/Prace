using Microsoft.Extensions.Logging;
using TODO.ViewModel;
using TODO.View;

namespace TODO
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<TODOViewModel>();
            builder.Services.AddTransient<TODOTaskViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<TODOTask>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}