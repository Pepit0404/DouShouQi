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
    // public Manager Gm
    //     => (Application.Current as App)!.TheMgr;

    public App app
        => (Application.Current as App)!;

    public Stub Stub = new Stub();

    public void StartGame(object sender, EventArgs e)
    {
        var button = (sender as Button)!;
        Game thisGame = (button.BindingContext as Game)!;
        app.TheMgr.game = thisGame;
        app.TheMgr.InitGame();
        this.IsVisible = false;
        Shell.Current.GoToAsync("//GamePage");
    }
    
    public void OnMenu(object sender, EventArgs e)
    {
        this.IsVisible = false;
    }
    
    public GameView()
    {
        InitializeComponent();
        BindingContext = this;

        listGame.ItemsSource = app.Games;
    }
}