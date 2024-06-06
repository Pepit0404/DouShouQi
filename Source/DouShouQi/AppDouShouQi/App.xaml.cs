using DouShouQiLib;
using DataContractPersist;

namespace AppDouShouQi
{
    
    public partial class App : Application
    {
        public Manager TheMgr { get; set; } = new Manager();

        public IPersistanceManager SaveManager = new XMLPersist();
        public App()
        { 
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
