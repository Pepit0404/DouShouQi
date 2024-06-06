namespace AppDouShouQi.Views;

public partial class pauseView : ContentView
{
	public pauseView()
	{
		InitializeComponent();
	}

    private void quitter(object _, EventArgs __)
    {
        this.IsVisible = false;
        Shell.Current.GoToAsync("//MainPage");
    }
    private void sauvegarde(object _, EventArgs __)
    {
        this.IsVisible = false;
        Shell.Current.GoToAsync("//MainPage");
    }
    private void reprendre(object _, EventArgs __)
    {
        this.IsVisible = false;
    }
}