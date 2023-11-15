using MAUIOTPReader.CustomControls;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

#if IOS || MACCATALYST
using MAUIOTPReader.Platforms.iOS.Handlers;
#elif ANDROID
using MAUIOTPReader.Platforms.Droid.Handlers;
#endif


namespace MAUIOTPReader;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureMauiHandlers(handlers => handlers.AddHandler<AutoFillEntry, AutoFillEntryHandler>())
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        CustomizeControl();
        return builder.Build();
    }

    private static void CustomizeControl()
    {
        EntryHandler.Mapper.AppendToMapping(nameof(AutoFillEntry), (handler, view)
            =>
        {

            if (view is AutoFillEntry)
            {
#if ANDROID
                handler.PlatformView.SetTextColor(Android.Graphics.Color.Yellow);
#elif IOS
                handler.PlatformView.TextColor = UIKit.UIColor.Black;
                handler.PlatformView.TextContentType = UIKit.UITextContentType.OneTimeCode;
#endif
            }

        });
    }
}
