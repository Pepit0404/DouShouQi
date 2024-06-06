using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DouShouQiLib;
using StubPackage;

namespace AppDouShouQi.Views;


public partial class GameView : ContentView
{
    public Manager Gm
        => (Application.Current as App)!.TheMgr;
    public IEnumerable<Game> LoadedGames 
        => (Application.Current as App)!.SaveManager.LoadGame();

    public Stub Stub = new Stub();

    public void StartGame(object sender, EventArgs e)
    {
        var button = (sender as Button)!;
        Game thisGame = (button.BindingContext as Game)!;
        Gm.game = thisGame;
        Gm.InitGame();
        this.IsVisible = false;
        Shell.Current.GoToAsync("//GamePage");
    }
    
    public GameView()
    {
        InitializeComponent();
        BindingContext = this;

        listGame.ItemsSource = LoadedGames;
    }
}