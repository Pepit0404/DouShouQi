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
    Case eau = new Case(4, 5, CaseType.Eau);
    Case terre = new Case(4, 6, CaseType.Terre);

    IRegles regles = new regleOrigin();
    Console.WriteLine("----------------bouger regles basiques");
    
    Console.WriteLine(regles.Bouger(terre, elephant, eau, null)); //non, elephant qui va dans leau
    Console.WriteLine(regles.Bouger(eau, souris, terre, elephant));//non, souris qui sort de leau pour manger un elephant
    Console.WriteLine(regles.Bouger(eau, souris, eau, null));//oui, une souris qui marche dans leau
    Console.WriteLine(regles.Bouger(terre, chien, eau, null)); //non, chien qui va dansleau
    Console.WriteLine(regles.Bouger(terre, elephant, terre, chien)); //oui, un elephant qui mange un chien
    Console.WriteLine(regles.Bouger(terre, elephant, terre, souris)); //non, un elephant qui mange une souris
    Console.WriteLine(regles.Bouger(terre,  souris, terre,elephant)); //oui, une souris qui mange un elephant
    Console.WriteLine(regles.Bouger(eau, souris, eau, souris)); //oui, une souris qui mange une autre souris toute 2 dans leau
    Console.WriteLine(regles.Bouger(eau, souris, terre, souris));//non, souris qui sort de leau pour manger une souris
    Console.WriteLine(regles.Bouger(terre, elephant, eau, chien)); //non elephant qui mange chien dans leau 

    Console.WriteLine("----------------bouger regles differentes");
    IRegles nregles = new regleVariente();
    Console.WriteLine(nregles.Bouger(terre, elephant, eau, null)); //non, elephant qui va dans leau
    Console.WriteLine(nregles.Bouger(eau, souris, terre, elephant));//non, souris qui sort de leau pour manger un elephant
    Console.WriteLine(nregles.Bouger(eau, souris, eau, null));//oui, une souris qui marche dans leau
    Console.WriteLine(nregles.Bouger(terre, chien, eau, null)); //oui, chien qui va dans leau
    Console.WriteLine(nregles.Bouger(terre, elephant, terre, chien)); //oui, un elephant qui mange un chien
    Console.WriteLine(nregles.Bouger(terre, elephant, terre, souris)); //oui, un elephant qui mange une souris
    Console.WriteLine(nregles.Bouger(terre, souris, terre, elephant)); //oui, une souris qui mange un elephant
    Console.WriteLine(nregles.Bouger(eau, souris, eau, souris)); //oui, une souris qui mange une autre souris toute 2 dans leau
    Console.WriteLine(nregles.Bouger(eau, souris, terre, souris));//non, souris qui sort de leau pour manger une souris
    Console.WriteLine(nregles.Bouger(eau, chien, eau, souris));//oui un chien dans leau qui mange une souris dans leau 
    Console.WriteLine(nregles.Bouger(eau, chien, eau, chien));//oui un chien dans leau qui mange un chien dans leau
    Console.WriteLine(nregles.Bouger(terre, chien, terre, chien));//oui un chien qui mange un chien
    Console.WriteLine(nregles.Bouger(terre,elephant,terre,chien));//oui un elephant qui mange un chien
    Console.WriteLine(nregles.Bouger(eau, souris, eau, chien));//non, souris qui mange chien
    Console.WriteLine(nregles.Bouger(terre, elephant, eau, chien)); //non elephant qui mange chien dans leau 
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
