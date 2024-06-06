using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    public interface IPersistanceManager
    {
        /// <summary>
        ///     Save a game
        /// </summary>
        /// <param name="games"></param>
        bool SaveAGame(Game game);
        bool DeleteAGame(string startDate);
        
        
        /// <summary>
        ///     Load a list of game
        /// </summary>
        /// <returns></returns>
        List<Game> LoadGame();

        void SaveGame(IEnumerable<Game> games);

        bool SaveAPlayer(Joueur j);
        bool DeleteAPlayer(string name);
        
        /// <summary>
        ///     Load a list of player
        /// </summary>
        /// <returns></returns>
        List<Joueur> LoadPlayer();
    }
}
