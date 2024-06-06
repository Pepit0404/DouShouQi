namespace AppDouShouQi.Pages;

using DouShouQiLib;
using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;

public partial class GamePage : ContentPage
{
    public Manager GM => (Application.Current as App)!.TheMgr;

    public Case? PlaceStart { get; set; }

    void OnTapCase(object sender, EventArgs e)
    {
        if (pause.IsVisible)
        {
            return;
        }
        var button = (sender as Button)!;
        Case thisCase = (button.BindingContext as Case)!;
        Debug.WriteLine($"[DEBUG] => {thisCase}");
        if (PlaceStart == null)
        {
            if (thisCase.Onthis.HasValue)
            {
                if (!GM.game.AppartientJC(thisCase.Onthis.Value)) return;
                PlaceStart = thisCase;
            }
        }
        else
        {
            if (thisCase == PlaceStart) 
            {
                PlaceStart = null;
                return;
            }
            bool ok = GM.game.MovePiece(PlaceStart, thisCase, GM.game.Plateau);
            PlaceStart = null;
            if (!ok) return;
            GM.game.IsFini();
            GM.game.ChangePlayer();
        }
        return;
    }

    void HomeButton(object sender, EventArgs e)
    {
        winBoard.IsVisible = false;
        Shell.Current.GoToAsync("//MainPage");
    }

    void GamePage_OnGameOver(object? sender, GameOverEventArgs e)
    {
        if (!e.End) return;
        labelNameVictory.Text = "Félicitation " + e.Winer + " !";
        winBoard.IsVisible = true;
    }

    void GamePage_StartingGame(object? sender, StartingGameEventArgs e)
    {
        GM.game.GameOver += GamePage_OnGameOver;
    }

    public GamePage()
	{
		InitializeComponent();
        BindingContext = this;
        GM.StartingGame += GamePage_StartingGame;
        GM.game.GameOver += GamePage_OnGameOver;
    }

    public void OnRegle(object sender, EventArgs e)
    {
        if (regle.IsVisible == false)
        {
            regle.IsVisible = true;
        }
        else 
        {
            regle.IsVisible = false;
        } 
    }
    public void OnPause(object sender, EventArgs e)
    {
        if (pause.IsVisible == false)
        {
            pause.IsVisible = true;
        }
        else
        {
            pause.IsVisible = false;
        }
    }
}