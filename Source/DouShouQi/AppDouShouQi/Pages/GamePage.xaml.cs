namespace AppDouShouQi.Pages;

using DouShouQiLib;
using System.Diagnostics;

public partial class GamePage : ContentPage
{
    public Manager GM => (Application.Current as App)!.GM;

    void OnTapCase(object sender, EventArgs e)
    {
        Debug.Print("Hello");
        return;
    }

    public GamePage()
	{
		InitializeComponent();
        BindingContext = this;
    }
}