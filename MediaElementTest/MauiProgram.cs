using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Sample.Pages.Views;
using CommunityToolkit.Maui.Sample.Pages;
using CommunityToolkit.Maui.Sample.ViewModels;
using CommunityToolkit.Maui.Sample.ViewModels.Views;

namespace MediaElementTest;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()


                .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

       // builder.Services.AddTransient<MediaElementPage, MediaElementViewModel>();
        builder.Services.AddTransientWithShellRoute<MediaElementPage, MediaElementViewModel>();
        builder.Services.AddTransient<ViewsGalleryPage, ViewsGalleryViewModel>();
        builder.Services.AddSingleton<IDeviceInfo>(DeviceInfo.Current);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    static IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>(this IServiceCollection services) where TPage : BasePage<TViewModel>
                                                                                                                    where TViewModel : BaseViewModel {
        return services.AddTransientWithShellRoute<TPage, TViewModel>(AppShell.GetPageRoute<TViewModel>());
    }

}