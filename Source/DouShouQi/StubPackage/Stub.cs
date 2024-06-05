using DouShouQiLib;
using System.Runtime.Serialization;
namespace StubPackage
{
    public class Stub
    {
        public Stub()
        {
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(new HumainJoueur("lala", 1) ); 
            joueurs.Add(new HumainJoueur("lolo", 2) );
        }
    }
}
