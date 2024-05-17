// See https://aka.ms/new-console-template for more information
using DouShouQiLib;

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
//void testPlateau()
//{
//    Joueur joueur1("toto");
//    Piece toto = new Piece(PieceType.chien);
//    Case tutu = new Case(0, 0, CaseType.Eau);

//    Console.WriteLine(toto);
//    Console.WriteLine(tutu);

//    Console.WriteLine("Ajout de toto sur tutu");
//    tutu.Onthis = toto;
//    Console.WriteLine(tutu);

//    Plateau plateau = new Plateau();
//    plateau.regle.initPlateau();
//    Console.WriteLine(plateau);
//    Console.WriteLine();

//    Plateau plateau2 = new Plateau(6, 6, 1);
//    plateau2.regle.initPlateau();
//    Console.WriteLine(plateau2);
//    Console.WriteLine();

//    Console.WriteLine("Ajout toto dans le plateau");
//    try
//    {
//        plateau[4, 4].Onthis = toto;
//        plateau[404, 4].Onthis = toto;
//    }
//    catch (MyOutOfRangeException e)
//    {
//        Console.WriteLine(e);
//    }
//    Console.WriteLine(plateau);
//}

void affichePlateau(Case[,] echequier)
{
    Joueur? j1 = null;
    Console.WriteLine("\n");
    Console.Write("\n    ----------------------------------------------------------------------------\n");
    Console.Write("        0          1          2          3          4          5          6\n");
    for (int i = 0; i < echequier.GetLength(0); i++)
    {
        Console.Write($"{i} | ");
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
            else if (echequier[i, j].Type == CaseType.Taniere)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }
            if (echequier[i, j].Onthis == null)
            {
                Console.Write("        ");
            }
            else
            {
                if (j1 == null)
                {
                    j1 = echequier[i, j].Onthis.Value.Proprietaire;
                }
                if (echequier[i, j].Onthis.Value.Proprietaire == j1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write((echequier[i, j].Onthis)?.ToString().PadLeft(4).PadRight(8));
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" | ");
        }
        Console.Write($"{i}");
        Console.Write("\n    ------------------------------------------------------------------------------\n");
    }
}

int askPos(int max)
{
    int pos;
    try
    {
        pos = int.Parse(Console.ReadLine());
        if (pos < 0 || pos > max)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Attention: Mettre un chiffre compris en 0 et {max}");
            Console.ForegroundColor= ConsoleColor.White;
            return -1;
        }
        return pos;
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Attention: Mettre un chiffre");
        Console.ForegroundColor= ConsoleColor.White;
        return -1;
    }
}

void testBoucle()
{
    void Game_OnBoardChanged(object? sender, BoardChangedEventArgs e)
    {
        Console.Clear();
        affichePlateau(e.NewBoard.echequier);
    }
    void Game_OnAppartient(object? sender, AppartientEventArgs e)
    {
        if (!e.Ok)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Veillez selectionnez une case avec une piece qui vous appartient, (celle ci appartient à {e.Proprietaire}) ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    void Game_OnPieceMoved(object? sender, PieceMovedEventArgs e)
    {
        if (!e.Ok)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Impossible de bouger le pion de la case  à ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{e.Depart}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" à ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{e.Arrivee}\n");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
        Console.Write($"Piece {e.Arrivee.Onthis} bouger de ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{e.Depart}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" à ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{e.Arrivee}\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    void Game_OnPlayerChanged(object? sender, PlayerChangedEventArgs e)
    {
        Console.WriteLine($"\nJoueur {e.NouveauJoueur} à votre tour !\n");
    }

    void Game_OnGameOver(object? sender, GameOverEventArgs e)
    {
        if (e.End)
        {
            Console.Clear();
            Console.WriteLine($"Félicitation {e.Winer} tu as gagner !");
        }
    }

    Game game = new Game(new regleOrigin(), new Joueur("toto"), new Joueur("titi"));
    game.BoardChanged += Game_OnBoardChanged;
    game.PieceMoved += Game_OnPieceMoved;
    game.PlayerChanged += Game_OnPlayerChanged;
    game.GameOver += Game_OnGameOver;
    game.LuiAppartient += Game_OnAppartient;

    affichePlateau(game.Plateau.echequier);
    while (!game.isFini())
    {
        game.ChangePlayer();
        int dLigne;
        int dCollone;
        int aLigne;
        int aCollone;
        do
        {
            Console.WriteLine("Qu'elle piece voulez-vous bouger ?");
            do
            {
                Console.Write("  Ligne: ");
                dLigne = askPos(8);
                dCollone = -1;
                if (dLigne != -1)
                {
                    Console.Write("  Collone: ");
                    dCollone = askPos(6);
                    if (dCollone != -1)
                    {
                        if (game.Plateau[dLigne, dCollone].Onthis.HasValue)
                        {
                            if (!game.AppartientJC(game.Plateau[dLigne, dCollone].Onthis.Value))
                            {
                                dLigne = -1;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Veillez selectionnez une case avec une piece");
                            Console.ForegroundColor = ConsoleColor.White;
                            dLigne = -1;
                        }
                    }
                }
            } while (dLigne == -1 || dCollone == -1);
            Console.WriteLine("Pour mettre la piece où ?");
            do
            {
                Console.Write("  Ligne: ");
                aLigne = askPos(8);
                aCollone = -1;
                if (aLigne != -1)
                {
                    Console.Write("  Collone: ");
                    aCollone = askPos(6);
                }
            } while (aLigne == -1 || aCollone == -1);
        } while (!game.MovePiece(game.Plateau[dLigne, dCollone], game.Plateau[aLigne, aCollone], game.Plateau));
        
    }
}


//testPlateau();
testBoucle();

