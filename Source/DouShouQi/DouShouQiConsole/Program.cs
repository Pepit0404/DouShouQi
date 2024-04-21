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

void testRegle()
{
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

Piece toto = new Piece(PieceType.chien);
Case tutu = new Case(0, 0, CaseType.Eau);

Console.WriteLine(toto);
Console.WriteLine(tutu);

Console.WriteLine("Ajout de toto sur tutu");
tutu.Onthis = toto;
Console.WriteLine(tutu);

Plateau plateau = new Plateau();
Console.WriteLine(plateau);
Console.WriteLine();

Console.WriteLine("Ajout toto dans le plateau");
try
{
    plateau[4, 4].Onthis = toto;
    plateau[404, 4].Onthis = toto;
} catch (MyOutOfRangeException e)
{
    Console.WriteLine(e);
}
Console.WriteLine(plateau);

testReglesMange();
testRegle();
