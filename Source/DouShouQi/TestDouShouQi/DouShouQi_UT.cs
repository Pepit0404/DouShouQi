using DouShouQiLib;
using System;
using System.IO.Compression;
using System.Text.RegularExpressions;
using static DouShouQiLib.Joueur;

namespace TestDouShouQi
{
    // REGLE ORIGINE
    public class RegleOrigin_UT
    {
        [Fact]
        public void ReglesOriginMange_UT()
        {
            Joueur j1 = new HumainJoueur("toto", 1);
            Piece souris = new (PieceType.souris, j1);
            Piece elephant = new (PieceType.elephant, j1);
            Piece chien = new (PieceType.chien, j1);
            IRegles regles = new regleOrigin();


            Assert.False(regles.Manger(elephant.Type, souris.Type)); // false, un �l�phant ne peux  pas manger une souris
            Assert.True(regles.Manger(souris.Type, elephant.Type)); // true, une souris peux manger un elephant
            Assert.True(regles.Manger(elephant.Type, chien.Type)); // true, un elephant peux manger un animal plus petit
            Assert.False(regles.Manger(souris.Type, chien.Type)); // false, une souris ne peux manger un animal plus grand
            Assert.True(regles.Manger(chien.Type, souris.Type)); // true, un chien peut manger un animal plus petit
            Assert.True(regles.Manger(chien.Type, chien.Type)); // true, un animal peut manger un autre de meme valeur
        }

        [Fact]
        public void ReglesOriginePouvoirBouger_UT()
        {
            Joueur j1 = new HumainJoueur("toto",1);
            Joueur j2 = new HumainJoueur("titi",2);
            Game game = new Game(new regleOrigin(), j1, j2);
            IRegles regles = game.Regle;
            Plateau plateau = game.Plateau;

            Case origine = new Case(1, 1, CaseType.Terre);
            origine.Onthis = new Piece(PieceType.tigre, j1);
            Case origineEau = new Case(1, 1, CaseType.Eau);
            origineEau.Onthis = new Piece(PieceType.souris, j1);
            Case arrive = new Case(1, 2, CaseType.Terre);
            arrive.Onthis = new Piece(PieceType.souris, j2);
            Case arriveEau = new Case(1, 2, CaseType.Eau);
            arriveEau.Onthis = new Piece(PieceType.souris, j2);
            Case arrivePiege = new Case(1, 2, CaseType.Piege);
            arrivePiege.Onthis = new Piece(PieceType.lion, j2);


            Assert.True(regles.PouvoirBouger(origine, new Case(1, 2, CaseType.Terre), plateau)); // true, simple changement de case
            Assert.False(regles.PouvoirBouger(origine, new Case(0, 0, CaseType.Terre), plateau)); // false, impossible en diagonale
            Assert.False(regles.PouvoirBouger(origine, new Case(1, 3, CaseType.Terre), plateau)); // false, impossible de saut� des cases
            Assert.False(regles.PouvoirBouger(origine, new Case(1,2, CaseType.Eau), plateau)); // false, pas possible d'aller dans l'eau
            origine.Onthis = new Piece(PieceType.souris, j1); // met une souris sur la case
            Assert.True(regles.PouvoirBouger(origine, new Case(1,2, CaseType.Eau), plateau)); // true, possible d'aller dans l'eau pour une souris
            Assert.True(regles.PouvoirBouger(origineEau, new Case(1, 2, CaseType.Terre), plateau)); // true, possible pour une souris de sortir de l'eau
            Assert.True(regles.PouvoirBouger(origineEau, arriveEau, plateau)); // true, une souris peut manger une autre qui est dans l'eau
            Assert.False(regles.PouvoirBouger(origine, arriveEau, plateau)); // false, une souris ne peut pas manger une autre en entrant dans l'eau
            Assert.False(regles.PouvoirBouger(origineEau, arrive, plateau)); // false, une souris ne peut pas manger en sortant de l'eau
            origine.Onthis = new Piece(PieceType.souris, j1); // met une souris sur la case
            Assert.True(regles.PouvoirBouger(origine, arrivePiege, plateau)); // true, une souris peut manger un animal plus gros qui est sur un piege
        }

        [Fact]
        public void RegleOriginEstFini()
        {
            Joueur j1 = new HumainJoueur("Toto", 1);
            Joueur j2 = new HumainJoueur("Tutu", 2);
            Piece j1Piece = new (PieceType.chien, j1);
            Piece j2Piece = new (PieceType.chien, j2);
            Game game = new (new regleOrigin(), j1, j2);

            Assert.False(game.Regle.EstFini(game)); // faux car situation de d�part
            game.Plateau[0, 3].Onthis = j1Piece; // mise d'une piece de j1 sur sa tani�re 
            Assert.False(game.Regle.EstFini(game)); //faux, car j1 sur sa tani�re et non sur celle de j2
            game.Plateau[8, 3].Onthis = j2Piece; // mise d'une piece de j1 sur sa tani�re
            Assert.False(game.Regle.EstFini(game)); //faux, car j2 sur sa tani�re et non sur celle de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j1 de tani�re 
            game.Plateau[8, 3].Onthis = j1Piece; // mise d'une piece de j1 sur la tani�re de j2
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 sur la tani�re de j2
            game.Plateau[8, 3].Onthis = null; // supression de la piece de j2 de tani�re 
            game.Plateau[0, 3].Onthis = j2Piece; // mise d'une piece de j2 sur la tani�re de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 sur la tani�re de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j2 de tani�re 
            game.Joueur1.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 ne poss�de plus de pieces
            game.Regle.initPlateau(game); // reset du plateau
            game.Joueur2.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 ne poss�de plus de pieces
        }
    }

    // REGLE VARIENTE
    public class RegleVariente_UT
    {
        [Fact]
        public void ReglesVarienteMange_UT()
        {
            IRegles regles = new regleVariente();

            Joueur j1 = new HumainJoueur("toto", 1);
            Piece souris = new (PieceType.souris, j1);
            Piece elephant = new (PieceType.elephant, j1);
            Piece chien = new (PieceType.chien, j1);

            Assert.True(regles.Manger(elephant.Type, souris.Type));
            Assert.True(regles.Manger(souris.Type, elephant.Type));
            Assert.True(regles.Manger(elephant.Type, chien.Type));
            Assert.False(regles.Manger(souris.Type, chien.Type));
            Assert.True(regles.Manger(chien.Type, souris.Type));
            Assert.True(regles.Manger(chien.Type, chien.Type));
        }

        [Fact]
        public void ReglesVarientePouvoirBouger_UT()
        {
            Joueur j1 = new HumainJoueur("toto", 1);
            Joueur j2 = new HumainJoueur("titi", 2);
            Game game = new Game(new regleVariente(), j1, j2);
            IRegles regles = game.Regle;
            Plateau plateau = game.Plateau;

            Case origine = new Case(1, 1, CaseType.Terre);
            origine.Onthis = new Piece(PieceType.tigre, j1);
            Case origineEau = new Case(1, 1, CaseType.Eau);
            origineEau.Onthis = new Piece(PieceType.souris, j1);
            Case arrive = new Case(1, 2, CaseType.Terre);
            arrive.Onthis = new Piece(PieceType.souris, j2);
            Case arriveEau = new Case(1, 2, CaseType.Eau);
            arriveEau.Onthis = new Piece(PieceType.souris, j2);
            Case arrivePiege = new Case(1, 2, CaseType.Piege);
            arrivePiege.Onthis = new Piece(PieceType.lion, j2);



            Assert.True(regles.PouvoirBouger(origine, new Case(1, 2, CaseType.Terre), plateau)); // true, simple changement de case
            Assert.False(regles.PouvoirBouger(origine, new Case(0, 0, CaseType.Terre), plateau)); // false, impossible en diagonale
            Assert.False(regles.PouvoirBouger(origine, new Case(1, 3, CaseType.Terre), plateau)); // false, impossible de saut� des cases
            Assert.False(regles.PouvoirBouger(origine, new Case(1, 2, CaseType.Eau), plateau)); // false, pas possible d'aller dans l'eau
            origine.Onthis = new Piece(PieceType.souris, j1); // met une souris sur la case
            Assert.True(regles.PouvoirBouger(origine, new Case(1, 2, CaseType.Eau), plateau)); // true, possible d'aller dans l'eau pour une souris
            Assert.True(regles.PouvoirBouger(origineEau, new Case(1, 2, CaseType.Terre), plateau)); // true, possible pour une souris de sortir de l'eau
            Assert.False(regles.PouvoirBouger(origineEau, arrive, plateau)); // false, une souris ne peut pas manger en sortant de l'eau
            Assert.True(regles.PouvoirBouger(origineEau, arriveEau, plateau)); // true, une souris peut manger une autre qui est dans l'eau
            origine.Onthis = new Piece(PieceType.chien, j1); // met une souris sur la case
            Assert.True(regles.PouvoirBouger(origine, new Case(1, 2, CaseType.Eau), plateau)); // true, possible d'aller dans l'eau pour un chien
            Assert.True(regles.PouvoirBouger(origineEau, new Case(1, 2, CaseType.Terre), plateau)); // true, possible pour un chien de sortir de l'eau
            Assert.True(regles.PouvoirBouger(origineEau, arriveEau, plateau)); // true, un chien peut manger un autre animal egale ou inf�rieur qui est dans l'eau
            origine.Onthis = new Piece(PieceType.souris, j1); // met une souris sur la case
            Assert.True(regles.PouvoirBouger(origine, arrivePiege, plateau)); // true, une souris peut manger un animal plus gros qui est sur un piege
        }

        [Fact]
        public void RegleVarienteEstFini()
        {
            Joueur j1 = new HumainJoueur("Toto", 1);
            Joueur j2 = new HumainJoueur("Tutu", 2);
            Piece j1Piece = new (PieceType.chien, j1);
            Piece j2Piece = new (PieceType.chien, j2);
            Game game = new (new regleVariente(), j1, j2);

            Assert.False(game.Regle.EstFini(game)); // faux car situation de d�part
            game.Plateau[0, 3].Onthis = j1Piece; // mise d'une piece de j1 sur sa tani�re 
            Assert.False(game.Regle.EstFini(game)); //faux, car j1 sur sa tani�re et non sur celle de j2
            game.Plateau[8, 3].Onthis = j2Piece; // mise d'une piece de j1 sur sa tani�re
            Assert.False(game.Regle.EstFini(game)); //faux, car j2 sur sa tani�re et non sur celle de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j1 de tani�re 
            game.Plateau[8, 3].Onthis = j1Piece; // mise d'une piece de j1 sur la tani�re de j2
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 sur la tani�re de j2
            game.Plateau[8, 3].Onthis = null; // supression de la piece de j2 de tani�re 
            game.Plateau[0, 3].Onthis = j2Piece; // mise d'une piece de j2 sur la tani�re de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 sur la tani�re de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j2 de tani�re 
            game.Joueur1.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 ne poss�de plus de pieces
            game.Regle.initPlateau(game); // reset du plateau
            game.Joueur2.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 ne poss�de plus de pieces
        }
    }

    public class Piece_UT
    {
        [Fact]
        public void MemePiece_UT()
        {
            Joueur j1 = new HumainJoueur("toto", 1);
            Joueur j2 = new HumainJoueur("tutu", 2);
            Piece piece1 = new (PieceType.chien, j1);
            Piece piece2 = new (PieceType.chat, j1);
            Piece piece3 = new (PieceType.chien, j2);
            Piece piece4 = new (PieceType.chien, j1);
            Assert.NotEqual(piece1, piece3);
            Assert.NotEqual(piece1, piece2);
            Assert.Equal(piece1, piece4);
        }
    }

    public class Joueur_UT
    {
        [Fact]
        public void Appartient_UT() 
        {
            Joueur j1 = new HumainJoueur("Toto", 1);
            Joueur j2 = new HumainJoueur("Tutu", 2);
            Piece j1Piece = new (PieceType.chien, j1);
            Assert.True(j1.Appartient(j1Piece)); // true, la piece lui appartient
            Assert.False(j2.Appartient(j1Piece)); // false, la piece appartient � j1
        }
    }
}
