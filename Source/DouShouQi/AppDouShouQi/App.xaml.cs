using System.ComponentModel;
using DouShouQiLib;
using DataContractPersist;

namespace AppDouShouQi
{
    
    public partial class App : Application, INotifyPropertyChanged
    {
        public Manager TheMgr { get; set; } = new Manager();

        public IPersistanceManager SaveManager = new XMLPersist(); 
        
        public List<Game> LoadedGames { get; private set; }

        public void LoadGames()
        {
            LoadedGames = SaveManager.LoadGame();
            OnPropertyChanged(nameof(LoadedGames));
        }
        
        public App()
        { 
            InitializeComponent();
            MainPage = new AppShell();
            LoadedGames = SaveManager.LoadGame();
        }
        
        public new event PropertyChangedEventHandler? PropertyChanged;

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
