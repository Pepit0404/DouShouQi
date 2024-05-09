// See https://aka.ms/new-console-template for more information
using DouShouQiLib;
using System.Text;



//void testRegle()
//{
//    Console.WriteLine("----------------");
//    Plateau plt = new Plateau();
//    if (plt.regle is regleOrigin) Console.WriteLine("ok");
//    else Console.WriteLine("pas bon");

//    plt = new Plateau(7,9,1);
//    if (plt.regle is regleVariente) Console.WriteLine("ok");
//    else Console.WriteLine("pas bon");

//    if (plt.regle is regleOrigin) Console.WriteLine("ok");
//    else Console.WriteLine("pas bon");

//    try
//    {
//        plt = new Plateau(9, 7, 8);
//    }
//    catch (NumberRulesException e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
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

void testPlateau2()
{
    Plateau plateau = new Plateau();
    plateau.regle.initPlateau(plateau);
    Case[,] echequier = plateau.echequier;
    echequier[0, 0].Onthis = new Piece(PieceType.chien);
    for (int i = 0; i < echequier.GetLength(0); i++)
    {
        for (int j = 0; j < echequier.GetLength(1); j++)
        {
            if (echequier[i, j].Type == CaseType.Terre)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            else if (echequier[i, j].Type == CaseType.Eau)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            else if (echequier[i, j].Type == CaseType.Piege)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else if (echequier[i,j].Type == CaseType.Taniere)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }
            if (echequier[i, j].Onthis == null)
            {
                Console.Write("    ");
            }
            else
            {
                Console.Write(echequier[i, j].Onthis);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" | ");
        }
        Console.Write("\n---------------------------------------------------\n");
    }
}

testPlateau();
testPlateau2();
//testRegle();
