namespace DouShouQiLib
{
    public struct Piece
    {
        public PieceType Type { get; init; }


        public Joueur Proprietaire { get; init; }

        /**
         *\ brief Constructeur de Piece
         *\ param type type de la pièce
         *\ param proprietaire le joueur qui possède cette pièce
         */
        public Piece(PieceType type, Joueur proprietaire)
        {
            Type = type;
            this.Proprietaire = proprietaire;
        }

        /**
         *\ brief Affichage des cases
         *\ return l'affichage des cases
         */
        public override string ToString()
        {
            return $"{Type}";
        }

        /**
         *\ brief Surcharge de l'opérateur == pour comparer 2 pièces entre elles
         */
        public static bool operator ==(Piece p1, Piece p2) => p1.Type == p2.Type && p1.Proprietaire == p2.Proprietaire;

        /**
         *\ brief Surcharge de l'opérateur =! pour comparer 2 pièces entre elles
         */
        public static bool operator !=(Piece p1, Piece p2) => !(p1 == p2);
    }

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

