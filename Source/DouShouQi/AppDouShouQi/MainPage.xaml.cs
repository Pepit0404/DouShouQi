using System.Collections;
using System.Diagnostics;
using AppDouShouQi.Pages;
using DataContractPersist;
using DouShouQiLib;

namespace AppDouShouQi
{
    public partial class MainPage : ContentPage
    {
        public Manager Mgr
        => (Application.Current as App)!.TheMgr;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = Mgr;
        }

        public void RunPlay(object sender, EventArgs e)
        {
            if (GameList.IsVisible) return;
            if (PlayStart.IsVisible)
            {
                PlayStart.IsVisible = false;
                return;
            }
            PlayStart.IsVisible = true;
            return;
        }

        public void showGames(object sendern, EventArgs e)
        {
            if (PlayStart.IsVisible) return;
            if (GameList.IsVisible)
            {
                GameList.IsVisible = false;
                return;
            }
            GameList.IsVisible = true;
        }

        public void ChangeTheme(object sender, EventArgs e)
        {
            if (Application.Current!.UserAppTheme == AppTheme.Dark)
            {
                Application.Current!.UserAppTheme = AppTheme.Light;
                return;
            }
            Application.Current!.UserAppTheme = AppTheme.Dark;
        }

        private void OnScoreBoard(object _, EventArgs __)
        {
            Navigation.PushAsync(new ScoreBoardPage());
        }
        private void OnCreditPage(object _, EventArgs __)
        {
            Shell.Current.GoToAsync("//CreditsPage");
        }
    }

}
