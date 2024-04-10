// See https://aka.ms/new-console-template for more information
using DouShouQiLib;

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
