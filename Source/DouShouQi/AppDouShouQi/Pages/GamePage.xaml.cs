namespace AppDouShouQi.Pages;

using DouShouQiLib;

public partial class GamePage : ContentPage
{
	public Plateau Plateau { get; } = new Plateau();
	public GamePage()
	{
		InitializeComponent();
        BindingContext = this;
    }
}