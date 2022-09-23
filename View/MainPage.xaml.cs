using Ivanov.ViewModel;

namespace Ivanov.View;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new AgentViewModel();
	}
}