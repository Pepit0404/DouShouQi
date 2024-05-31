namespace AppDouShouQi.Pages;

public partial class CreditsPage : ContentPage
{
	public CreditsPage()
	{
		InitializeComponent();
	}

	private void OnClickedReturn(object _, EventArgs __)
	{
        Shell.Current.GoToAsync("//MainPage");
    }
}