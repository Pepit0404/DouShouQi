using DouShouQiLib;

namespace AppDouShouQi
{
    
    public partial class App : Application
    {
        public Manager TheMgr { get; set; } = new Manager();
        public App()
        { 
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
