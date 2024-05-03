// See https://aka.ms/new-console-template for more information
using DouShouQiLib;

void testReglesMange()
{
    Piece souris = new Piece(PieceType.souris);
    Piece elephant = new Piece(PieceType.elephant);
    Piece chien = new Piece(PieceType.chien);

    IRegles regles = new regleOrigin();

    Console.WriteLine(regles.Manger(elephant.Type, souris.Type)); // non
    Console.WriteLine(regles.Manger(souris.Type, elephant.Type)); // oui
    Console.WriteLine(regles.Manger(elephant.Type, chien.Type)); // oui
    Console.WriteLine(regles.Manger(souris.Type, chien.Type)); // non
    Console.WriteLine(regles.Manger(chien.Type, souris.Type)); // oui

    Console.WriteLine("-----------------------------------------------");
    IRegles nregles = new regleVariente();

    Console.WriteLine(nregles.Manger(elephant.Type, souris.Type)); // oui
    Console.WriteLine(nregles.Manger(souris.Type, elephant.Type)); // oui
    Console.WriteLine(nregles.Manger(elephant.Type, chien.Type)); // oui
    Console.WriteLine(nregles.Manger(souris.Type, chien.Type)); // non
    Console.WriteLine(nregles.Manger(chien.Type, souris.Type)); // oui
}
void testReglesBouger()
{
    Piece souris = new Piece(PieceType.souris);
    Piece elephant = new Piece(PieceType.elephant);
    Piece chien = new Piece(PieceType.chien);
    Case eau = new Case(0, 0, CaseType.Eau);
    Case eauvide = new Case(0, 0, CaseType.Eau);
    Case terre = new Case(0, 0, CaseType.Terre);
    Case terrevide = new Case(0, 0, CaseType.Terre);
    Case terre2 = new Case(0, 0, CaseType.Terre);
    Case terre3 = new Case(0, 0, CaseType.Terre);
    Case eau2 = new Case(0, 0, CaseType.Eau);
    eau.Onthis = souris;
    terre.Onthis = elephant;
    terre2.Onthis = chien;
    terre3.Onthis = souris;
    eau2.Onthis = chien;

    IRegles regles = new regleOrigin();
    Console.WriteLine("----------------bouger regles basiques");

    Console.WriteLine(regles.PouvoirBouger(terre, eauvide)); //non, elephant qui va dans leau
    Console.WriteLine(regles.PouvoirBouger(eau, terre));//non, souris qui sort de leau pour manger un elephant
    Console.WriteLine(regles.PouvoirBouger(eau, eauvide));//oui, une souris qui marche dans leau
    Console.WriteLine(regles.PouvoirBouger(terre2, eauvide)); //non, chien qui va dansleau
    Console.WriteLine(regles.PouvoirBouger(terre, terre2)); //oui, un elephant qui mange un chien
    Console.WriteLine(regles.PouvoirBouger(terre, terre3)); //non, un elephant qui mange une souris
    Console.WriteLine(regles.PouvoirBouger(terre3, terre)); //oui, une souris qui mange un elephant
    Console.WriteLine(regles.PouvoirBouger(eau, eau)); //oui, une souris qui mange une autre souris toute 2 dans leau
    Console.WriteLine(regles.PouvoirBouger(eau, terre3));//non, souris qui sort de leau pour manger une souris
    Console.WriteLine(regles.PouvoirBouger(terre, eau)); //non elephant qui mange chien dans leau 

    Console.WriteLine("----------------bouger regles differentes");
    IRegles nregles = new regleVariente();

    Console.WriteLine(nregles.PouvoirBouger(terre, eauvide)); //non, elephant qui va dans leau
    Console.WriteLine(nregles.PouvoirBouger(eau, terre));//non, souris qui sort de leau pour manger un elephant
    Console.WriteLine(nregles.PouvoirBouger(eau, eauvide));//oui, une souris qui marche dans leau
    Console.WriteLine(nregles.PouvoirBouger(terre2, eauvide)); //oui, chien qui va dans leau
    Console.WriteLine(nregles.PouvoirBouger(terre, terre2)); //oui, un elephant qui mange un chien
    Console.WriteLine(nregles.PouvoirBouger(terre, terre3)); //oui, un elephant qui mange une souris
    Console.WriteLine(nregles.PouvoirBouger(terre3, terre)); //oui, une souris qui mange un elephant
    Console.WriteLine(nregles.PouvoirBouger(eau, eau)); //oui, une souris qui mange une autre souris toute 2 dans leau
    Console.WriteLine(nregles.PouvoirBouger(eau, terre3));//non, souris qui sort de leau pour manger une souris
    Console.WriteLine(nregles.PouvoirBouger(eau2, eau));//oui un chien dans leau qui mange une souris dans leau 
    Console.WriteLine(nregles.PouvoirBouger(eau2, eau2));//oui un chien dans leau qui mange un chien dans leau
    Console.WriteLine(nregles.PouvoirBouger(terre2, terre2));//oui un chien qui mange un chien
    Console.WriteLine(nregles.PouvoirBouger(terre, terre2));//oui un elephant qui mange un chien
    Console.WriteLine(nregles.PouvoirBouger(eau, eau2));//non, souris qui mange chien
    Console.WriteLine(nregles.PouvoirBouger(terre, eau2)); //non elephant qui mange chien dans leau 
    Console.WriteLine(nregles.PouvoirBouger(terre2, eau2));//oui un chien qui mange un chien
}


void testRegle()
{
    Console.WriteLine("----------------");
    Plateau plt = new Plateau();
    if (plt.regle is regleOrigin) Console.WriteLine("ok");
    else Console.WriteLine("pas bon");

    plt = new Plateau(7,9,1);
    if (plt.regle is regleVariente) Console.WriteLine("ok");
    else Console.WriteLine("pas bon");

    if (plt.regle is regleOrigin) Console.WriteLine("ok");
    else Console.WriteLine("pas bon");

    try
    {
        plt = new Plateau(9, 7, 8);
    }
    catch (NumberRulesException e)
    {
        Console.WriteLine(e.Message);
    }
}
void testPlateau()
{
    Piece toto = new Piece(PieceType.chien);
    Case tutu = new Case(0, 0, CaseType.Eau);

    Console.WriteLine(toto);
    Console.WriteLine(tutu);

    Console.WriteLine("Ajout de toto sur tutu");
    tutu.Onthis = toto;
    Console.WriteLine(tutu);

    Plateau plateau = new Plateau();
    plateau.regle.initPlateau(plateau);
    Console.WriteLine(plateau);
    Console.WriteLine();

    Plateau plateau2 = new Plateau(6, 6, 1);
    plateau2.regle.initPlateau(plateau2);
    Console.WriteLine(plateau2);
    Console.WriteLine();

    Console.WriteLine("Ajout toto dans le plateau");
    try
    {
        plateau[4, 4].Onthis = toto;
        plateau[404, 4].Onthis = toto;
    }
    catch (MyOutOfRangeException e)
    {
        Console.WriteLine(e);
    }
    Console.WriteLine(plateau);
}


testPlateau();
testReglesMange();
testReglesBouger();
testRegle();
