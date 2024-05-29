using DouShouQiLib;
using static DouShouQiLib.Joueur;

namespace AppDouShouQi
{
    public partial class App : Application
    {
        public Manager GM { get; } = new Manager(); 
        public App()
        {
            GM.Game = new Game(new regleOrigin(), new HumainJoueur("Toto"), new HumainJoueur("Toto"));
            GM.Plateau = GM.Game.Plateau;
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
