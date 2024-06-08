using DouShouQiLib;
using System.Diagnostics;
using static DouShouQiLib.Joueur;

namespace AppDouShouQi.Views;

public partial class JouerViews : ContentView
{
	
	public Manager  Mgr
        => (Application.Current as App)!.TheMgr;

	public Joueur Joueur1 { get; set; }
		= new HumainJoueur("", 1);
	public Joueur Joueur2 { get; set; } = new HumainJoueur("", 2);

	public string regles { get; set; } = "classic";


    public JouerViews()
	{
		InitializeComponent();
		BindingContext = this;
			
    }
	private void CreatePlayers_Clicked(object sender, EventArgs e)
	{
		if (Joueur1.Name == "" || Joueur2.Name == "") return;
		Mgr.CreatePlayer(Joueur1.Name, Joueur1.Id);
		Mgr.CreatePlayer(Joueur2.Name, Joueur2.Id);
		Mgr.setRegles(regles);
		Mgr.CreateGame();
		this.IsVisible = false;

		Shell.Current.GoToAsync("//GamePage");
    }

	public void OnMenu(object sender, EventArgs e)
	{
        this.IsVisible = false;
    }

}