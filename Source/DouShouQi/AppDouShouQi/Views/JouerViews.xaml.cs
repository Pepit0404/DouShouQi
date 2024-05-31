using DouShouQiLib;
using static DouShouQiLib.Joueur;

namespace AppDouShouQi.Views;

public partial class JouerViews : ContentView
{
	
	public Manager  Mgr
        => (Application.Current as App).TheMgr;

	public Joueur Joueur1 { get; set; }
		= new RandomJoueur("oui", 1);
	public Joueur Joueur2 { get; set; } = new RandomJoueur("oui", 2);


    public JouerViews()
	{
		InitializeComponent();
		BindingContext = this;
	}
	private void CreatePlayers_Clicked(object sender, EventArgs e)
	{
		Mgr.CreatePlayer(Joueur1.Name, Joueur1.Id);
		Mgr.CreatePlayer(Joueur2.Name, Joueur2.Id);

	}
	
}