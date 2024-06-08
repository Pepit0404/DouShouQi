namespace AppDouShouQi.Pages;

using DouShouQiLib;
using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;

public partial class GamePage : ContentPage
{
    public Manager GM => (Application.Current as App)!.TheMgr;

    public IPersistanceManager SaveManager => (Application.Current as App)!.SaveManager;
    
    public Case? PlaceStart { get; set; }
    private Button selected { get; set; }

    void OnTapCase(object sender, EventArgs e)
    {
        if (pause.IsVisible)
        {
            return;
        }
        Debug.WriteLine(sender.ToString());
        var button = (sender as Button)!;
        Case thisCase = (button.BindingContext as Case)!;
        if (PlaceStart == null)
        {
            if (thisCase.Onthis.HasValue)
            {
                if (!GM.game.AppartientJC(thisCase.Onthis.Value)) return;
                PlaceStart = thisCase;
                selected = button;
                selected.BorderColor = Color.FromArgb("#FFFFFF");
            }
        }
        else
        {
            selected.BorderColor = Color.Parse("Transparent");
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
        //Debug.WriteLine(SaveManager.DeleteAGame(GM.game));
        (Application.Current as App)!.Delete_Game(GM.game);
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
        if (GM.Regles is regleOrigin)
        {
            if (regleOrigin.IsVisible == false)
            {
                regleOrigin.IsVisible = true;
            }
            else
            {
                regleOrigin.IsVisible = false;
            }
        }
        if(GM.Regles is regleVariente)
        {
            if (regleVariente.IsVisible == false)
            {
                regleVariente.IsVisible = true;
            }
            else
            {
                regleVariente.IsVisible = false;
            }
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