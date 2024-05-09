using TipCalculator.Views;
namespace TipCalculator;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
