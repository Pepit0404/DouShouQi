namespace DouShouQiLib
{
    public struct Piece
    {
        public PieceType Type { get; init; }


        public Joueur Proprietaire { get; init; } 


        public Piece(PieceType type, Joueur proprietaire)
        {
            Type = type;
            this.Proprietaire = proprietaire;
        }

        public override string ToString()
        {
            return $"{Type}";
        }

        public static bool operator ==(Piece p1, Piece p2) => p1.Type == p2.Type && p1.Proprietaire == p2.Proprietaire;

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

