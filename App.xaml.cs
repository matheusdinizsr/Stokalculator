using Stokalculator;

namespace Stokalculator
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
		}

		protected override Window CreateWindow(IActivationState activationState)
		{
			var window = base.CreateWindow(activationState);

			const int newWidth = 550;
			const int newHeight = 780;

			window.Width = newWidth;
			window.Height = newHeight;

			return window;
		}
	}
}
