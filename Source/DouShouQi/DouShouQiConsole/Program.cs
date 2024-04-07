// See https://aka.ms/new-console-template for more information
using DouShouQiLib;

Piece toto = new Piece("erwan", PieceType.chien);
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
plateau.echequier[4,4].Onthis = toto;
Console.WriteLine(plateau);
