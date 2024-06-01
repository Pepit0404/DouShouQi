namespace AppDouShouQi.Pages;

using DouShouQiLib;
using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;

public partial class GamePage : ContentPage
{
    public Manager GM => (Application.Current as App)!.TheMgr;

    public string tourJ => "Au tour de " + GM.game.JoueurCourant;

    public Case? placeStart { get; set; }

    void OnTapCase(object sender, EventArgs e)
    {
        var button = (sender as Button)!;
        Case thisCase = (button.BindingContext as Case)!;
        if (placeStart == null)
        {
            if (thisCase.Onthis.HasValue)
            {
                if (!GM.game.AppartientJC(thisCase.Onthis.Value) ) return;
                placeStart = thisCase;
            }
        }
        else
        {
            bool ok = GM.game.MovePiece(placeStart, thisCase, GM.game.Plateau);
            placeStart = null;
            if (ok)
            {
                GM.game.IsFini();
                GM.game.ChangePlayer();
            }
        }
        return;
    }

    void HomeButton(object sender, EventArgs e)
    {
        winBoard.IsVisible = false;
        Shell.Current.GoToAsync("//MainPage");
    }

    void GamePage_OnPlayerChanged(object? sender, PlayerChangedEventArgs e)
    {
        OnPropertyChanged(nameof(tourJ));
    }

    void GamePage_OnGameOver(object? sender, GameOverEventArgs e)
    {
        if (!e.End) return;
        labelNameVictory.Text = "Félicitation " + e.Winer + " !";
        winBoard.IsVisible = true;
        Console.WriteLine("[DEBUG] => END");
    }

    public GamePage()
	{
		InitializeComponent();
        BindingContext = this;
        GM.game.PlayerChanged += GamePage_OnPlayerChanged;
        GM.game.GameOver += GamePage_OnGameOver;
    }

}