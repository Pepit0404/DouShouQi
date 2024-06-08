using System.Collections.ObjectModel;
using DouShouQiLib;

namespace AppDouShouQi.Pages;

public partial class ScoreBoardPage : ContentPage
{
	public IOrderedEnumerable<Joueur> Players
		=> (Application.Current as App)!.Players.OrderByDescending(j => j.nbVictory);

	public Joueur First { get; set; }
	public Joueur Second { get; set; }
	public Joueur Third { get; set; }
	
	public ObservableCollection<Joueur> Other { get; set; }
	
	public ScoreBoardPage()
	{
		First = Players.ElementAt(0);
		Second = Players.ElementAt(1);
		Third = Players.ElementAt(2);
		Other = new ObservableCollection<Joueur>(Players.Skip(3));
		InitializeComponent();
		BindingContext = this;

		//listJoueur.ItemsSource = Other;
	}

	private void OnClickedReturn(object _, EventArgs __)
	{
		Navigation.PopAsync();
	}
	
	
}