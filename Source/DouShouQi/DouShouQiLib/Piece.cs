namespace DouShouQiLib
{
    public struct Piece
    {
        public PieceType Type { get; init; }


        public Joueur Proprietaire { get; init; } 


        public Piece(PieceType type, Joueur proprietaire)
        {
            Type = type;
            Proprietaire = proprietaire;
        }

        public override string ToString()
        {
            return $"{Type}";
        }
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

