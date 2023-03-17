using CommunityToolkit.Maui.Sample.Pages;
using CommunityToolkit.Maui.Sample.Pages.Views;
using CommunityToolkit.Maui.Sample.ViewModels;
using CommunityToolkit.Maui.Sample.ViewModels.Views;

namespace MediaElementTest;

public partial class AppShell : Shell
{
    static readonly IReadOnlyDictionary<Type, (Type GalleryPageType, Type ContentPageType)> viewModelMappings = new Dictionary<Type, (Type, Type)>(new[]
{
		
        CreateViewModelMapping<MediaElementPage, MediaElementViewModel, ViewsGalleryPage, ViewsGalleryViewModel>(),
 
    });

    public AppShell()
    {
        InitializeComponent();
    }

    public static string GetPageRoute<TViewModel>() where TViewModel : BaseViewModel {
        return GetPageRoute(typeof(TViewModel));
    }

    static string GetPageRoute(Type galleryPageType, Type contentPageType) => $"//{galleryPageType.Name}/{contentPageType.Name}";

    public static string GetPageRoute(Type viewModelType) {
        if (!viewModelType.IsAssignableTo(typeof(BaseViewModel))) {
            throw new ArgumentException($"{nameof(viewModelType)} must implement {nameof(BaseViewModel)}", nameof(viewModelType));
        }

        if (!viewModelMappings.TryGetValue(viewModelType, out (Type GalleryPageType, Type ContentPageType) mapping)) {
            throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings. Please register your ViewModel in {nameof(AppShell)}.{nameof(viewModelMappings)}");
        }

        var uri = new UriBuilder("", GetPageRoute(mapping.GalleryPageType, mapping.ContentPageType));
        return uri.Uri.OriginalString[..^1];
    }

    static KeyValuePair<Type, (Type GalleryPageType, Type ContentPageType)> CreateViewModelMapping<TPage, TViewModel, TGalleryPage, TGalleryViewModel>() where TPage : BasePage<TViewModel>
                                                                                                                                                            where TViewModel : BaseViewModel
                                                                                                                                                            where TGalleryPage : BaseGalleryPage<TGalleryViewModel>
                                                                                                                                                            where TGalleryViewModel : BaseGalleryViewModel {
        return new KeyValuePair<Type, (Type GalleryPageType, Type ContentPageType)>(typeof(TViewModel), (typeof(TGalleryPage), typeof(TPage)));
    }
}

