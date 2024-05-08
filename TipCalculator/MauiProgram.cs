using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using The49.Maui.Insets;

namespace TipCalculator;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseInsets();

        return builder.Build();
	}
}
