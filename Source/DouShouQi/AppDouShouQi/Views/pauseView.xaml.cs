using Windows.ApplicationModel.Store;
using DataContractPersist;
using DouShouQiLib;

namespace AppDouShouQi.Views;

public partial class pauseView : ContentView
{
    private Manager Gm 
        => (Application.Current as App)!.TheMgr;

    private IPersistanceManager SaveManager
        => (Application.Current as App)!.SaveManager;
    
	public pauseView()
	{
		InitializeComponent();
        IPersistanceManager SaveManager = new XMLPersist();
    }

    private void quitter(object _, EventArgs __)
    {
        this.IsVisible = false;
        Shell.Current.GoToAsync("//MainPage");
    }
    private void sauvegarde(object _, EventArgs __)
    {
        this.IsVisible = false;
        SaveManager.SaveAGame(Gm.game);
        (Application.Current as App)!.LoadGames();
        Shell.Current.GoToAsync("//MainPage");
    }
    private void reprendre(object _, EventArgs __)
    {
        this.IsVisible = false;
    }
}