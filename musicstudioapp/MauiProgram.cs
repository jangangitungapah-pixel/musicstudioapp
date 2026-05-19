using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using musicstudioapp.Services;
using SkiaSharp.Views.Maui.Controls.Hosting;
using UraniumUI;
using UraniumUI.Material;

namespace musicstudioapp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IStudioDataService, DummyStudioDataService>();

            return builder.Build();
        }
    }
}