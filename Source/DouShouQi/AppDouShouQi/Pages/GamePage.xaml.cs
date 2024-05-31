namespace AppDouShouQi.Pages;

using DouShouQiLib;
using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;

public partial class GamePage : ContentPage
{
    public Manager GM => (Application.Current as App)!.GM;

    void OnTapCase(object sender, EventArgs e)
    {
        var button = (sender as ImageButton)!;
        //int x = int.Parse(button[0]);
        //int y = int.Parse(button[1]);
        Case thisCase = (button.BindingContext as Case)!;
        Debug.WriteLine(thisCase.X);
        return;
    }

    public GamePage()
	{
		InitializeComponent();
        BindingContext = this;
    }
}