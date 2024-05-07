namespace DouShouQiLib
{
    public struct Piece
    {
        public PieceType Type { get; init; }


        //public Joueur proprietaire *joueur => _joueur;
        //private Joueur proprietaire *_joueur; // juste id


        public Piece(PieceType type)
        {
            Type = type;
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

