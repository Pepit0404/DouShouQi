using DouShouQiLib;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System;
using System.Runtime.Serialization;
using System.IO;
using static System.Console;

namespace DataContractPersist
{
    public class XMLPersist : IPersistanceManager
    {
        DataContractSerializer Serializer = new DataContractSerializer(typeof(Joueur));

        public void LoadData()
        {
            
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
            
            string xmlFile = "joueur.xml";
            using (Stream s = File.Create(xmlFile))
            {
                Serializer.WriteObject(s, joueur1);
            }

        } 
    }
}
