using DouShouQiLib;
using DouShouQiLib.Interface;
using System.Runtime.Serialization;
namespace StubPackage
{
     public class  Stub :IPersistanceManager
    {
        public Stub()
        {
            Joueur joueur1 = new HumainJoueur("lala", 1);
            Joueur joueur2 = new HumainJoueur("lolo", 2);
            joueur1.Joueurs.Add(joueur2);
            
        }

        public void LoadData()
        {
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "<your>//<path>//<to>//<your>//<XML>//<files>//<folder>//"));
            string xmlFile = "joueur.xml";
            Joueur joueurs;
            var serializer = new DataContractSerializer(typeof(Joueur));
            using (Stream s = File.OpenRead(xmlFile))
            {
                joueurs = serializer.ReadObject(s) as Joueur;
            }
        }

        public void SaveData(Joueur joueur1)
        {
            throw new NotImplementedException();
        }
    }
}
