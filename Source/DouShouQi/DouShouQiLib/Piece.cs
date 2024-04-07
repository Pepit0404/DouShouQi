namespace DouShouQiLib
{
    public class Piece
    {
        public string Name { get; init; }

        public PieceType Type { get; init; }


        //public Joueur proprietaire *joueur => _joueur;
        //private Joueur proprietaire *_joueur;


        public Piece(string name, PieceType type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Type}";
        }
    }

    public enum PieceType
    {
        souris,
        chat,
        chien,
        loup,
        leopart,
        tigre,
        lion,
        elephant
    }
}
