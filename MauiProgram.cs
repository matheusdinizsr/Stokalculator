using AndreasReitberger.Shared.Hosting;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Stokalculator
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.InitializeSharedMauiStyles();
				


#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
