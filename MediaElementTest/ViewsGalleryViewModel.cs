using CommunityToolkit.Maui.Sample.Models;


namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

public sealed class ViewsGalleryViewModel : BaseGalleryViewModel
{
	public ViewsGalleryViewModel()
		: base(new[]
		{
			SectionModel.Create<MediaElementViewModel>("MediaElement", Colors.Red, "MediaElement is a view for playing video and audio"),
				})
	{
	}
}