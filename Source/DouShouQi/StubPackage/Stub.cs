using DouShouQiLib;
using System.Runtime.Serialization;
namespace StubPackage
{
    public class Stub
    {
        public List<Game> Games { get; } = new List<Game>();

        public List<Joueur> Joueurs { get;  } = new List<Joueur>();
        
        public Stub()
        {
            Joueur j1 = new HumainJoueur("j1", 1);
            Joueur j2 = new HumainJoueur("j2", 2);
            Joueur j3 = new HumainJoueur("j3", 1);
            Joueurs.Add(j1); 
            Joueurs.Add(j2);
            Joueurs.Add(j3);
            Games.Add( new Game(new regleOrigin(), j1, j2) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
            Games.Add( new Game(new regleVariente(), j1, j3) );
        }
    }
}
