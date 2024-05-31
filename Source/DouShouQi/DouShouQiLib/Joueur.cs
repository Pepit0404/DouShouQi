using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQiLib
{
    [DataContract]
    abstract public class Joueur : INotifyPropertyChanged
    {


        /// <summary>
        ///     Vérifie si une pièce appartient à joueur
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>bool</returns>
        /// 
        

        public bool Appartient(Piece piece)
        {
            if (piece.Proprietaire == this)
            {
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        abstract public Case[] ChoisirCoup(Game game);

        /// <summary>
        ///    Liste des pièces que possède le joueur
        /// </summary>
        public List<Piece> Liste_Piece { get; private set; }

        /// <summary>
        ///    Nom du joueur
        /// </summary>
        [DataMember]
        public string? Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged("Name");

            }
        }
        private string name;
        public int Id {  get; set; }



        /// <summary>
        ///     Constructeur de Joueur
        /// </summary>
        /// <param name="identifiant"></param>
        public Joueur(string identifiant, int id)
        {
            Name = identifiant;
            Liste_Piece = new List<Piece>();
            Id = id;
        }


        /// <summary>
        ///     Affichage des Joueur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
    [DataContract]
    public class RandomJoueur : Joueur
    {

        /// <summary>
        ///     Choisit un coup aléatoirement parmit une liste de tous les coups possible
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Un coup possible</returns>
        public override Case[] ChoisirCoup(Game game)
        {
            System.Threading.Thread.Sleep(1000);
            Case[] cout = new Case[2];
            Piece choisit = this.Liste_Piece[new Random().Next(0, this.Liste_Piece.Count)];
            int x = 0;
            int y = 0;
            for (int i = 0; i < game.Plateau.width; i++)
            {
                for (int j = 0; j < game.Plateau.height; j++)
                {
                    if (game.Plateau[i, j].Onthis.HasValue)
                    {
                        if (game.Plateau[i, j].Onthis.Value == choisit)
                        {
                            x=i; y=j;
                            i = game.Plateau.width;
                            j = game.Plateau.height;
                        }
                    }
                }
            }
            List<Case> possibilite = game.Regle.CoupPossible(game.Plateau[x, y], game);

            cout[0] = game.Plateau[x, y];
            cout[1] = possibilite[new Random().Next(0, possibilite.Count)];

            return cout;
        }

        /// <summary>
        ///    Constructeur d'un joueur ordinateur
        /// </summary>
        /// <param name="identifiant"></param>
        public RandomJoueur(string identifiant, int id) : base(identifiant,id)
        { }
    }
    [DataContract]
    public class HumainJoueur : Joueur
    {
        /// <summary>
        ///    Ne sert pas, car le joueur humain choisira lui même son coup
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Rien</returns>
        public override Case[] ChoisirCoup(Game game)
        {
            Case[] cout = new Case[2];
            return cout;
        }

        /// <summary>
        ///    Constructeur d'un joueur humain
        /// </summary>
        /// <param name="identifiant"></param>
        public HumainJoueur(string identifiant, int id) : base(identifiant, id)
        { }
    }
}

