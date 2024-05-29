using DouShouQiLib;

namespace AppDouShouQi
{
    public partial class MainPage : ContentPage
    {
        public Manager Mgr
        => (Application.Current as App).TheMgr;

        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = Mgr;
        }

        public void RunPlay(object sender, EventArgs e)
        {
            if (PlayStart.IsVisible)
            {
                PlayStart.IsVisible = false;
                return;
            }
            PlayStart.IsVisible = true;
            return;
        }
    }

}
