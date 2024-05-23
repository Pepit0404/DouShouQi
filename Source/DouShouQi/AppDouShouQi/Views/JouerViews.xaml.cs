using DouShouQiLib;

namespace AppDouShouQi.Views;

public partial class JouerViews : ContentView
{
	
	public Manager  Mgr
        => (Application.Current as App).TheMgr;

	public Joueur Joueur1 {  get; set; }
	public Joueur Joueur2 { get; set; }


    public JouerViews()
	{
		InitializeComponent();
	}
	private void CreatePlayers_Clicked(object sender, EventArgs e)
	{
		Mgr.Joueur[0]=new Joueur.RandomJoueur("lalala");
		Mgr.Joueur[1]=new Joueur.RandomJoueur("lololo");
	}
	
}