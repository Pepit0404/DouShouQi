using DouShouQiLib;
using static DouShouQiLib.Joueur;
namespace AppDouShouQi
{
    
    public partial class App : Application
    {
        public Manager TheMgr { get; set; }= new Manager();
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
