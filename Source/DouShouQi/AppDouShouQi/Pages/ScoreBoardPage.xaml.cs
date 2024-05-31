namespace AppDouShouQi.Pages;

public partial class ScoreBoardPage : ContentPage
{
	public ScoreBoardPage()
	{
		InitializeComponent();
	}

	private void OnClickedReturn(object _, EventArgs __)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}