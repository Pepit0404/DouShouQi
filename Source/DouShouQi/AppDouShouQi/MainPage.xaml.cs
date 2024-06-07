using System.Collections;
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

        private void OnScoreBoard(object _, EventArgs __)
        {
            Shell.Current.GoToAsync("//ScoreBoardPage");
        }
        private void OnCreditPage(object _, EventArgs __)
        {
            Shell.Current.GoToAsync("//CreditsPage");
        }
    }

}
