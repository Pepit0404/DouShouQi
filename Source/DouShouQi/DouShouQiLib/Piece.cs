namespace DouShouQiLib
{
    public struct Piece
    {
        /// <summary>
        ///    Animal qui représente la pièce parmit PieceType
        /// </summary>
        public PieceType Type { get; init; }

        /// <summary>
        ///    le joueur qui possède cette pièce
        /// </summary>
        public Joueur Proprietaire { get; init; }

        /// <summary>
        ///     Constructeur d'une pièce
        /// </summary>
        /// <param name="type"></param>
        /// <param name="proprietaire"></param>
        public Piece(PieceType type, Joueur proprietaire)
        {
            Type = type;
            this.Proprietaire = proprietaire;
        }

        /// <summary>
        ///     Affichage d'une pièce
        /// </summary>
        /// <returns>L'affichage</returns>
        public override string ToString()
        {
            return $"{Type}";
        }

        /// <summary>
        ///     Surcharge de l'opérateur == pour comparer 2 pièces entre elles
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Piece p1, Piece p2) => p1.Type == p2.Type && p1.Proprietaire == p2.Proprietaire;

        /// <summary>
        ///     Surcharge de l'opérateur =! pour comparer 2 pièces entre elles
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>bool</returns>
        public static bool operator !=(Piece p1, Piece p2) => !(p1 == p2);
    }

    /// <summary>
    ///    Enumération qui définit les types que peut prendre une pièce
    /// </summary>
    public enum PieceType
    {
        inconnue,
        souris,
        chat,
        chien,
        loup,
        leopard,
        tigre,
        lion,
        elephant
    }

   
}

