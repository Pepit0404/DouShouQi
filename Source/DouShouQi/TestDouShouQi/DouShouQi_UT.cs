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
            Joueur j1 = new HumainJoueur("toto");
            Piece souris = new (PieceType.souris, j1);
            Piece elephant = new (PieceType.elephant, j1);
            Piece chien = new (PieceType.chien, j1);
            IRegles regles = new regleOrigin();


            Assert.False(regles.Manger(elephant.Type, souris.Type));
            Assert.True(regles.Manger(souris.Type, elephant.Type));
            Assert.True(regles.Manger(elephant.Type, chien.Type));
            Assert.False(regles.Manger(souris.Type, chien.Type));
            Assert.True(regles.Manger(chien.Type, souris.Type));
            Assert.True(regles.Manger(chien.Type, chien.Type));
        }

        [Fact]
        public void ReglesOriginePouvoirBouger_UT()
        {
            Joueur j1 = new HumainJoueur("toto");
            Piece souris = new (PieceType.souris, j1);
            Piece elephant = new (PieceType.elephant, j1);
            Piece chien = new (PieceType.chien, j1);
            Case eau = new (0, 0, CaseType.Eau);
            Case eauvide = new (0, 0, CaseType.Eau);
            Case terre = new (0, 0, CaseType.Terre);
            Case terrevide = new (0, 0, CaseType.Terre);
            Case terre2 = new (0, 0, CaseType.Terre);
            Case terre3 = new (0, 0, CaseType.Terre);
            Case eau2 = new (0, 0, CaseType.Eau);
            eau.Onthis = souris;
            terre.Onthis = elephant;
            terre2.Onthis = chien;
            terre3.Onthis = souris;
            eau2.Onthis = chien;

            Game game = new Game(new regleOrigin(), j1, new HumainJoueur("titi"));
            IRegles regles = game.Regle;
            Plateau plateau = game.Plateau;
 
            Assert.False(regles.PouvoirBouger(terre, eauvide, plateau)); //non, elephant qui va dans leau
            Assert.False(regles.PouvoirBouger(eau, terre, plateau));//non, souris qui sort de leau pour manger un elephant
            Assert.True(regles.PouvoirBouger(eau, eauvide, plateau));//oui, une souris qui marche dans leau
            Assert.False(regles.PouvoirBouger(terre2, eauvide, plateau)); //non, chien qui va dansleau
            Assert.True(regles.PouvoirBouger(terre, terre2, plateau)); //oui, un elephant qui mange un chien
            Assert.False(regles.PouvoirBouger(terre, terre3, plateau)); //non, un elephant qui mange une souris
            Assert.True(regles.PouvoirBouger(terre3, terre, plateau)); //oui, une souris qui mange un elephant
            Assert.True(regles.PouvoirBouger(eau, eau, plateau)); //oui, une souris qui mange une autre souris toute 2 dans leau
            Assert.False(regles.PouvoirBouger(eau, terre3, plateau));//non, souris qui sort de leau pour manger une souris
            Assert.False(regles.PouvoirBouger(terre, eau, plateau)); //non elephant qui mange chien dans leau
        }

        [Fact]
        public void RegleOriginEstFini()
        {
            Joueur j1 = new HumainJoueur("Toto");
            Joueur j2 = new HumainJoueur("Tutu");
            Piece j1Piece = new (PieceType.chien, j1);
            Piece j2Piece = new (PieceType.chien, j2);
            Game game = new (new regleOrigin(), j1, j2);

            Assert.False(game.Regle.EstFini(game)); // faux car situation de départ
            game.Plateau[0, 3].Onthis = j1Piece; // mise d'une piece de j1 sur sa tanière 
            Assert.False(game.Regle.EstFini(game)); //faux, car j1 sur sa tanière et non sur celle de j2
            game.Plateau[8, 3].Onthis = j2Piece; // mise d'une piece de j1 sur sa tanière
            Assert.False(game.Regle.EstFini(game)); //faux, car j2 sur sa tanière et non sur celle de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j1 de tanière 
            game.Plateau[8, 3].Onthis = j1Piece; // mise d'une piece de j1 sur la tanière de j2
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 sur la tanière de j2
            game.Plateau[8, 3].Onthis = null; // supression de la piece de j2 de tanière 
            game.Plateau[0, 3].Onthis = j2Piece; // mise d'une piece de j2 sur la tanière de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 sur la tanière de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j2 de tanière 
            game.Joueur1.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 ne possède plus de pieces
            game.Regle.initPlateau(game); // reset du plateau
            game.Joueur2.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 ne possède plus de pieces
        }
    }

    // REGLE VARIENTE
    public class RegleVariente_UT
    {
        [Fact]
        public void ReglesVarienteMange_UT()
        {
            IRegles regles = new regleVariente();

            Joueur j1 = new HumainJoueur("toto");
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
        public void ReglesPouvoirBouger_UT()
        {
            Joueur j1 = new HumainJoueur("toto");
            Piece souris = new (PieceType.souris, j1);
            Piece elephant = new (PieceType.elephant, j1);
            Piece chien = new (PieceType.chien, j1);
            Case eau = new (0, 0, CaseType.Eau);
            Case eauvide = new (0, 0, CaseType.Eau);
            Case terre = new (0, 0, CaseType.Terre);
            Case terrevide = new (1, 1, CaseType.Terre);
            Case terre2 = new (0, 0, CaseType.Terre);
            Case terre3 = new (0, 0, CaseType.Terre);
            Case eau2 = new (0, 0, CaseType.Eau);
            eau.Onthis = souris;
            terre.Onthis = elephant;
            terre2.Onthis = chien;
            terre3.Onthis = souris;
            eau2.Onthis = chien;

            Game game = new (new regleOrigin(), j1, new HumainJoueur("titi"));
            IRegles regles = game.Regle;
            Plateau plateau = game.Plateau;

            Assert.False(regles.PouvoirBouger(terre, eauvide, plateau)); //non, elephant qui va dans leau
            Assert.False(regles.PouvoirBouger(eau, terre, plateau));//non, souris qui sort de leau pour manger un elephant
            Assert.True(regles.PouvoirBouger(eau, eauvide, plateau));//oui, une souris qui marche dans leau
            Assert.True(regles.PouvoirBouger(terre2, eauvide, plateau)); //oui, chien qui va dans leau
            Assert.True(regles.PouvoirBouger(terre, terre2, plateau)); //oui, un elephant qui mange un chien
            Assert.True(regles.PouvoirBouger(terre, terre3, plateau)); //oui, un elephant qui mange une souris
            Assert.True(regles.PouvoirBouger(terre3, terre, plateau)); //oui, une souris qui mange un elephant
            Assert.True(regles.PouvoirBouger(eau, eau, plateau)); //oui, une souris qui mange une autre souris toute 2 dans leau
            Assert.False(regles.PouvoirBouger(eau, terre3, plateau));//non, souris qui sort de leau pour manger une souris
            Assert.True(regles.PouvoirBouger(eau2, eau, plateau));//oui un chien dans leau qui mange une souris dans leau 
            Assert.True(regles.PouvoirBouger(eau2, eau2, plateau));//oui un chien dans leau qui mange un chien dans leau
            Assert.True(regles.PouvoirBouger(terre2, terre2, plateau));//oui un chien qui mange un chien
            Assert.True(regles.PouvoirBouger(terre, terre2, plateau));//oui un elephant qui mange un chien
            Assert.False(regles.PouvoirBouger(eau, eau2, plateau));//non, souris qui mange chien
            Assert.False(regles.PouvoirBouger(terre, eau2, plateau)); //non elephant qui mange chien dans leau 
            Assert.True(regles.PouvoirBouger(terre2, eau2, plateau));//oui un chien qui mange un chien
            Assert.False(regles.PouvoirBouger(terre, terrevide, plateau)); //non, car impossible d'aller en diagonal
        }

        [Fact]
        public void RegleVarienteEstFini()
        {
            Joueur j1 = new HumainJoueur("Toto");
            Joueur j2 = new HumainJoueur("Tutu");
            Piece j1Piece = new (PieceType.chien, j1);
            Piece j2Piece = new (PieceType.chien, j2);
            Game game = new (new regleVariente(), j1, j2);

            Assert.False(game.Regle.EstFini(game)); // faux car situation de départ
            game.Plateau[0, 3].Onthis = j1Piece; // mise d'une piece de j1 sur sa tanière 
            Assert.False(game.Regle.EstFini(game)); //faux, car j1 sur sa tanière et non sur celle de j2
            game.Plateau[8, 3].Onthis = j2Piece; // mise d'une piece de j1 sur sa tanière
            Assert.False(game.Regle.EstFini(game)); //faux, car j2 sur sa tanière et non sur celle de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j1 de tanière 
            game.Plateau[8, 3].Onthis = j1Piece; // mise d'une piece de j1 sur la tanière de j2
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 sur la tanière de j2
            game.Plateau[8, 3].Onthis = null; // supression de la piece de j2 de tanière 
            game.Plateau[0, 3].Onthis = j2Piece; // mise d'une piece de j2 sur la tanière de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 sur la tanière de j1
            game.Plateau[0, 3].Onthis = null; // supression de la piece de j2 de tanière 
            game.Joueur1.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j1 ne possède plus de pieces
            game.Regle.initPlateau(game); // reset du plateau
            game.Joueur2.Liste_Piece.Clear(); // supprime toute les pieces de j1
            Assert.True(game.Regle.EstFini(game)); //vrai, car j2 ne possède plus de pieces
        }
    }

    public class Piece_UT
    {
        [Fact]
        public void MemePiece_UT()
        {
            Joueur j1 = new HumainJoueur("toto");
            Joueur j2 = new HumainJoueur("tutu");
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
            Joueur j1 = new HumainJoueur("Toto");
            Joueur j2 = new HumainJoueur("Tutu");
            Piece j1Piece = new (PieceType.chien, j1);
            Assert.True(j1.Appartient(j1Piece)); // true, la piece lui appartient
            Assert.False(j2.Appartient(j1Piece)); // false, la piece appartient à j1
        }
    }
}
