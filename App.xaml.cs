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

			const int newWidth = 390;
			const int newHeight = 500;

			window.Width = newWidth;
			window.Height = newHeight;
			window.MaximumHeight = newHeight;
			window.MinimumHeight = newHeight;
			window.MaximumWidth = newWidth;
			window.MinimumWidth = newWidth;

			window.X = 750;
			window.Y = 200;

			return window;
		}
	}
}
