using DouShouQiLib;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml;
using System;
using System.Runtime.Serialization;
using System.IO;
using static System.Console;

namespace DataContractPersist
{
    public class XMLPersist : IPersistanceManager
    {
        private string path = "../../../SAVE/";
        private string nameFileGame = "games.xml";
        private string nameFilePLayer = "player.xml";

        public bool SaveAGame(Game game)
        {
            List<Game> allReadySaved = LoadGame();
            allReadySaved.Add(game);
            SaveGame(allReadySaved);
            return true;
        }

        public bool DeleteAGame(string startDate)
        {
            List<Game> allReadySaved = LoadGame();
            foreach (Game game in allReadySaved)
            {
                if (game.startDate == startDate)
                {
                    bool ok = allReadySaved.Remove(game);
                    SaveGame(allReadySaved);
                    return ok;
                }
            }

            return false;
        }

        public List<Game> LoadGame()
        {
            List<Game> games = new List<Game>();

            var serializer = new DataContractSerializer(typeof(List<Game>));
            using (Stream s = File.OpenRead($"{path}{nameFileGame}") )
            {
                games = (serializer.ReadObject(s) as List<Game>)!;
            }   
            return games;
        }

        public void SaveGame(IEnumerable<Game> games)
        {
            if (games == null) return;
            DataContractSerializer Serializer = 
                new DataContractSerializer(typeof(IEnumerable<Game>), 
                    new DataContractSerializerSettings(){PreserveObjectReferences = true});
            
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using TextWriter tw = File.CreateText($"{path}{nameFileGame}");
            using XmlWriter Write = XmlWriter.Create(tw, settings);
            Serializer.WriteObject(Write, games);
        }

        public bool SaveAPlayer(Joueur joueur)
        {
            List<Joueur> allReadySaved = LoadPlayer();
            foreach (Joueur j in allReadySaved)
            {
                if (j.Name == joueur.Name) return false;
            }
            allReadySaved.Add(joueur);
            SavePlayer(allReadySaved);
            return true;
        }

        public bool DeleteAPlayer(string name)
        {
            List<Joueur> players = LoadPlayer();
            
            foreach (Joueur player in players)
            {
                if (player.Name == name)
                {
                    bool ok =  players.Remove(player);
                    SavePlayer(players);
                    return ok;
                }
            }
            return false;
        }

        public List<Joueur> LoadPlayer()
        {
            List<Joueur> players = new List<Joueur>();

            var serializer = new DataContractSerializer(typeof(List<Joueur>) );
            using (Stream s = File.OpenRead($"{path}{nameFileGame}") )
            {
                players = (serializer.ReadObject(s) as List<Joueur>)!;
            }
            
            return players;
        }

        /// <summary>
        ///     Load a list of player
        /// </summary>
        /// <param name="players"></param>
        private void SavePlayer(IEnumerable<Joueur> players)
        {
            if (players == null) return;
            DataContractSerializer Serializer = 
                new DataContractSerializer(typeof(IEnumerable<Joueur>), 
                    new DataContractSerializerSettings(){PreserveObjectReferences = true});
            
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using TextWriter tw = File.CreateText($"{path}{nameFileGame}");
            using XmlWriter Write = XmlWriter.Create(tw, settings);
            Serializer.WriteObject(Write, players);
        } 
    }
}
