using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DouShouQiLib;

namespace AppDouShouQi.Views;


public partial class GameView : ContentView
{
    public IEnumerable<Game> LoadedGames 
        => (Application.Current as App)!.SaveManager.LoadGame();

    
    
    public GameView()
    {
        InitializeComponent();
        BindingContext = this;
    }
}