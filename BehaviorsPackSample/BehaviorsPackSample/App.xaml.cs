using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace BehaviorsPackSample
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			XF.Material.Forms.Material.Init(this);

			MainPage = new MaterialPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
