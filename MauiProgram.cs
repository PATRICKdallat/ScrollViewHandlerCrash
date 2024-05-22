using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace AnimationCrashOnNavigation;

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


#if ANDROID
        	ScrollViewHandler.CommandMapper.ReplaceMapping<MyScrollView, ScrollViewHandler>(nameof(IScrollView.RequestScrollTo), (handler,view,args) => 
		{
			if (args is not ScrollToRequest request)
			{
				return;
			}
			
			var context = handler.PlatformView.Context;
			if (context == null)
			{
				return;
			}

			var horizontalOffsetDevice = (int)context.ToPixels(request.HorizontalOffset);
			var verticalOffsetDevice = (int)context.ToPixels(request.VerticalOffset);

			handler.PlatformView.ScrollTo(horizontalOffsetDevice, verticalOffsetDevice,
				request.Instant, () =>
				{
					if (handler?.PlatformView != null) // handler.IsConnected();
					{
						handler?.VirtualView?.ScrollFinished();
					}
				});
		});
#endif
		return builder.Build();
	}
}
