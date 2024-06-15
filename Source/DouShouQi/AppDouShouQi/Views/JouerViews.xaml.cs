using DouShouQiLib;
using System.Diagnostics;
using static DouShouQiLib.Joueur;

namespace AppDouShouQi.Views;

public partial class JouerViews : ContentView
{
	
	public Manager  Mgr
        => (Application.Current as App)!.TheMgr;

	public IPersistanceManager SaveManager
		=> (Application.Current as App)!.SaveManager;

	public Joueur Joueur1 
		=> Mgr.Joueurs[0];
	public Joueur Joueur2 
		=> Mgr.Joueurs[1];

	public string regles { get; set; } = "classic";


    public JouerViews()
	{
		InitializeComponent();
		BindingContext = this;
	}
	private void ActionStart(object sender, EventArgs e)
	{
		if (Joueur1.Name == "" || Joueur2.Name == "") return;
		
		Mgr.CreatePlayer(Joueur1.Name, Joueur1.Id, Joueur1.nbVictory, Joueur1 is RandomJoueur);
		Mgr.CreatePlayer(Joueur2.Name, Joueur2.Id, Joueur2.nbVictory, Joueur2 is RandomJoueur);
		Mgr.setRegles(regles);
		Mgr.CreateGame();
		this.IsVisible = false;

		(Application.Current as App)!.AddPlayer(Joueur1);
		(Application.Current as App)!.AddPlayer(Joueur2);

		Shell.Current.GoToAsync("//GamePage");
    }

	public void OnMenu(object sender, EventArgs e)
	{
        this.IsVisible = false;
    }

	public void LoadPlayer(object sender, EventArgs e)
	{
		Button button = (sender as Button)!;
		PlayerLoadedView.IsVisible = true;
		if (button == LoadPlayer1)
		{
			(Application.Current as App)!.loadingPlayer = 1;
		}
		if (button == LoadPlayer2)
		{
			(Application.Current as App)!.loadingPlayer = 2;
		}
	}

}