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


public partial class PlayerLoadedView : ContentView
{
    // public Manager Gm
    //     => (Application.Current as App)!.TheMgr;

    public App app
        => (Application.Current as App)!;
    
    public Manager Gm
        => (Application.Current as App)!.TheMgr;

    public void AddPlayer(object sender, EventArgs e)
    {
        var button = (sender as Button)!;
        Joueur thisPlayer = (button.BindingContext as Joueur)!;

        Gm.SetNameJoueurs(app.loadingPlayer, thisPlayer.Name!);
        app.loadingPlayer = 0;
        
        this.IsVisible = false;
    }

    public void AddRandom(Object sender, EventArgs e)
    {
        Gm.SetRobotPlayer(app.loadingPlayer);
        app.loadingPlayer = 0;

        this.IsVisible = false;
    }
    
    public void OnMenu(object sender, EventArgs e)
    {
        this.IsVisible = false;
    }
    
    public PlayerLoadedView()
    {
        InitializeComponent();
        BindingContext = this;

        listPlayer.ItemsSource = app.Players;
    }
}