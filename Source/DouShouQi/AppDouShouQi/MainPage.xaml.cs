namespace AppDouShouQi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        public void RunPlay(object _, EventArgs __)
        {
            if (PlayStart.IsVisible)
            {
                PlayStart.IsVisible = false;
                return;
            }
            PlayStart.IsVisible = true;
            return;
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
