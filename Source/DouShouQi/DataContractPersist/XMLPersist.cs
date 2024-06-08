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
        private string path = "../../../../../.SAVE/";
        private string nameFileGame = "games.xml";
        private string nameFilePLayer = "player.xml";

        public bool SaveAGame(Game game)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + path + nameFileGame);
            
            if (!File.Exists(file))
            {
                List<Game> games = new List<Game>();
                games.Add(game);
                SaveGame(games);
                return true;
            }
            
            List<Game> allReadySaved = LoadGame();
            
            foreach (Game g in allReadySaved)
            {
                if (g.startDate == game.startDate && g.Joueur1.Name == game.Joueur1.Name && g.Joueur2.Name == game.Joueur2.Name)
                {
                    allReadySaved.Remove(g);
                    break;
                }
            }
            
            allReadySaved.Add(game);
            SaveGame(allReadySaved);
            return true;
        }

        public bool DeleteAGame(Game game)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + path + nameFileGame);
            if (!File.Exists(file))
            {
                return false;
            }
            
            List<Game> allReadySaved = LoadGame();
            foreach (Game g in allReadySaved)
            {
                if (g.startDate == game.startDate && g.Joueur1.Name == game.Joueur1.Name && g.Joueur2.Name == game.Joueur2.Name)
                {
                    bool ok = allReadySaved.Remove(g);
                    SaveGame(allReadySaved);
                    return ok;
                }
            }

            return false;
        }

        public List<Game> LoadGame()
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + path + nameFileGame);
            if (!File.Exists(file))
            {
                SaveGame(new List<Game>());
            }
            
            List<Game> games = new List<Game>();

            var serializer = new DataContractSerializer(typeof(List<Game>));
            using (Stream s = File.OpenRead(file) )
            {
                games = (serializer.ReadObject(s) as List<Game>)!;
            }   
            return games;
        }

        private void SaveGame(IEnumerable<Game> games)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + path + nameFileGame);

            DataContractSerializer Serializer = 
                new DataContractSerializer(typeof(IEnumerable<Game>), 
                    new DataContractSerializerSettings(){PreserveObjectReferences = true});
            
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using TextWriter tw = File.CreateText(file);
            using XmlWriter Write = XmlWriter.Create(tw, settings);
            Serializer.WriteObject(Write, games);
        }

        public bool SaveAPlayer(Joueur player)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + path + nameFilePLayer);

            if (!File.Exists(file))
            {
                List<Joueur> players = new List<Joueur>();
                players.Add(player);
                SavePlayer(players);
                return true;
            }
            
            List<Joueur> allReadySaved = LoadPlayer();
            foreach (Joueur j in allReadySaved)
            {
                if (j.Name == player.Name)
                {
                    allReadySaved.Remove(j);
                    allReadySaved.Add(player);
                    SavePlayer(allReadySaved);
                    return true;
                }
            }
            allReadySaved.Add(player);
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
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + path + nameFilePLayer);

            if (!File.Exists(file))
            {
                SavePlayer(new List<Joueur>());
            }
            
            List<Joueur> players = new List<Joueur>();

            var serializer = new DataContractSerializer(typeof(List<Joueur>) );
            using (Stream s = File.OpenRead(file) )
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
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + path + nameFilePLayer);

            if (players == null) return;
            DataContractSerializer Serializer = 
                new DataContractSerializer(typeof(IEnumerable<Joueur>), 
                    new DataContractSerializerSettings(){PreserveObjectReferences = true});
            
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using TextWriter tw = File.CreateText(file);
            using XmlWriter Write = XmlWriter.Create(tw, settings);
            Serializer.WriteObject(Write, players);
        } 
    }
}
