using DouShouQiLib;
using System;
using System.Text.RegularExpressions;
using static DouShouQiLib.Joueur;

namespace TestDouShouQi
{
    public class DouShouQi_UT
    {
        [Fact]
        public void ReglesMange_UT()
        {
            Joueur j1 = new HumainJoueur("toto");
            Piece souris = new Piece(PieceType.souris, j1);
            Piece elephant = new Piece(PieceType.elephant , j1);
            Piece chien = new Piece(PieceType.chien , j1);

            IRegles regles = new regleOrigin();

            Assert.False(regles.Manger(elephant.Type, souris.Type));
            Assert.True(regles.Manger(souris.Type, elephant.Type));
            Assert.True(regles.Manger(elephant.Type, chien.Type));
            Assert.False(regles.Manger(souris.Type, chien.Type));
            Assert.True(regles.Manger(chien.Type, souris.Type));
            Assert.True(regles.Manger(chien.Type, chien.Type));

            regles = new regleVariente();

            Assert.True(regles.Manger(elephant.Type, souris.Type));
            Assert.True(regles.Manger(souris.Type, elephant.Type));
            Assert.True(regles.Manger(elephant.Type, chien.Type));
            Assert.False(regles.Manger(souris.Type, chien.Type));
            Assert.True(regles.Manger(chien.Type, souris.Type));
            Assert.True(regles.Manger(chien.Type, chien.Type));
        }

        //[Fact]
        //public void ReglesPouvoirBouger_UT()
        //{
        //    Joueur j1 = new Joueur("toto");
        //    Piece souris = new Piece(PieceType.souris, j1);
        //    Piece elephant = new Piece(PieceType.elephant, j1);
        //    Piece chien = new Piece(PieceType.chien, j1);
        //    Case eau = new Case(0, 0, CaseType.Eau);
        //    Case eauvide = new Case(0, 0, CaseType.Eau);
        //    Case terre = new Case(0, 0, CaseType.Terre);
        //    Case terrevide = new Case(0, 0, CaseType.Terre);
        //    Case terre2 = new Case(0, 0, CaseType.Terre);
        //    Case terre3 = new Case(0, 0, CaseType.Terre);
        //    Case eau2 = new Case(0, 0, CaseType.Eau);
        //    eau.Onthis = souris;
        //    terre.Onthis = elephant;
        //    terre2.Onthis = chien;
        //    terre3.Onthis = souris;
        //    eau2.Onthis = chien;

        //    IRegles regles = new regleOrigin();

        //    Assert.False(regles.PouvoirBouger(terre, eauvide)); //non, elephant qui va dans leau
        //    Assert.False(regles.PouvoirBouger(eau, terre));//non, souris qui sort de leau pour manger un elephant
        //    Assert.True(regles.PouvoirBouger(eau, eauvide));//oui, une souris qui marche dans leau
        //    Assert.False(regles.PouvoirBouger(terre2, eauvide)); //non, chien qui va dansleau
        //    Assert.True(regles.PouvoirBouger(terre, terre2)); //oui, un elephant qui mange un chien
        //    Assert.False(regles.PouvoirBouger(terre, terre3)); //non, un elephant qui mange une souris
        //    Assert.True(regles.PouvoirBouger(terre3, terre)); //oui, une souris qui mange un elephant
        //    Assert.True(regles.PouvoirBouger(eau, eau)); //oui, une souris qui mange une autre souris toute 2 dans leau
        //    Assert.False(regles.PouvoirBouger(eau, terre3));//non, souris qui sort de leau pour manger une souris
        //    Assert.False(regles.PouvoirBouger(terre, eau)); //non elephant qui mange chien dans leau 

        //    IRegles nregles = new regleVariente();

        //    Assert.False(nregles.PouvoirBouger(terre, eauvide)); //non, elephant qui va dans leau
        //    Assert.False(nregles.PouvoirBouger(eau, terre));//non, souris qui sort de leau pour manger un elephant
        //    Assert.True(nregles.PouvoirBouger(eau, eauvide));//oui, une souris qui marche dans leau
        //    Assert.True(nregles.PouvoirBouger(terre2, eauvide)); //oui, chien qui va dans leau
        //    Assert.True(nregles.PouvoirBouger(terre, terre2)); //oui, un elephant qui mange un chien
        //    Assert.True(nregles.PouvoirBouger(terre, terre3)); //oui, un elephant qui mange une souris
        //    Assert.True(nregles.PouvoirBouger(terre3, terre)); //oui, une souris qui mange un elephant
        //    Assert.True(nregles.PouvoirBouger(eau, eau)); //oui, une souris qui mange une autre souris toute 2 dans leau
        //    Assert.False(nregles.PouvoirBouger(eau, terre3));//non, souris qui sort de leau pour manger une souris
        //    Assert.True(nregles.PouvoirBouger(eau2, eau));//oui un chien dans leau qui mange une souris dans leau 
        //    Assert.True(nregles.PouvoirBouger(eau2, eau2));//oui un chien dans leau qui mange un chien dans leau
        //    Assert.True(nregles.PouvoirBouger(terre2, terre2));//oui un chien qui mange un chien
        //    Assert.True(nregles.PouvoirBouger(terre, terre2));//oui un elephant qui mange un chien
        //    Assert.False(nregles.PouvoirBouger(eau, eau2));//non, souris qui mange chien
        //    Assert.False(nregles.PouvoirBouger(terre, eau2)); //non elephant qui mange chien dans leau 
        //    Assert.True(nregles.PouvoirBouger(terre2, eau2));//oui un chien qui mange un chien
        //}
        [Fact] 
        public void MemePiece_UT()
        {
            Joueur j1 = new HumainJoueur("toto");
            Joueur j2 = new HumainJoueur("tutu");
            Piece piece1 = new Piece(PieceType.chien, j1);
            Piece piece2 = new Piece(PieceType.chat, j1);
            Piece piece3 = new Piece(PieceType.chien, j2);
            Piece piece4 = new Piece(PieceType.chien, j1);
            Assert.NotEqual(piece1, piece3);
            Assert.NotEqual(piece1, piece2);
            Assert.Equal(piece1, piece4);
        }
       
    }


}
