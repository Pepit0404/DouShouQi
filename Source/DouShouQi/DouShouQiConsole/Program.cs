// See https://aka.ms/new-console-template for more information
using DouShouQiLib;
using StubPackage;
using DataContractPersist;
using System;
using System.Data;
using System.Globalization;
using static DouShouQiLib.Joueur;

// nécéssaire
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
            switch (echequier[i, j].Type)
            {
                case CaseType.Terre:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case CaseType.Eau:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case CaseType.Piege:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case CaseType.Taniere:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
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
                Console.ForegroundColor = (echequier[i, j].Onthis.Value.Proprietaire == j1) ? ConsoleColor.White : ConsoleColor.Black;

                Console.Write((echequier[i, j].Onthis)?.ToString().PadRight(8));
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" | ");
        }
        Console.Write($"{i}");
        Console.Write("\n    ------------------------------------------------------------------------------\n");
    }
}

void displayTitre()
{
    Console.Clear();
    Console.ForegroundColor= ConsoleColor.Green;
    Console.Write("\n==============================================================================\n");
    Console.Write("\n");
    Console.WriteLine("         ______            _____ _                 _____ _ ");
    Console.WriteLine("         |  _  \\          /  ___| |               |  _  (_)");
    Console.WriteLine("         | | | |___  _   _\\ `--.| |__   ___  _   _| | | |_ ");
    Console.WriteLine("         | | | / _ \\| | | |`--. \\ '_ \\ / _ \\| | | | | | | |");
    Console.WriteLine("         | |/ / (_) | |_| /\\__/ / | | | (_) | |_| \\ \\/' / |");
    Console.WriteLine("         |___/ \\___/ \\__,_\\____/|_| |_|\\___/ \\__,_|\\_/\\_\\_|");
    Console.WriteLine("");
    Console.Write("\n==============================================================================\n");
    Console.ForegroundColor= ConsoleColor.White;
}

static int AskPos(int max)
{
    int pos;
    try
    {
        pos = int.Parse(Console.ReadLine());
        if (pos < 0 || pos > max)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Attention: Mettre un chiffre compris en 0 et {max}");
            Console.ForegroundColor = ConsoleColor.White;
            return -1;
        }
        return pos;
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Attention: Mettre un chiffre");
        Console.ForegroundColor = ConsoleColor.White;
        return -1;
    }
}

// Les deux 
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
    Console.Write($"La piece {e.Arrivee.Onthis} à bougé de la case ");
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
static Case[] Game_OnAskMooveAI(int maxX, int maxY, Game game)
{
    Case[] couts = game.JoueurCourant.ChoisirCoup(game);
    return couts;
}
static Case AskCase(int maxX, int maxY, Game game)
{
    int line;
    int column;
    do
    {
        Console.WriteLine("Qu'elle piece bouger ?");
        Console.Write("  Ligne: ");
        line = AskPos(maxX);
        column = -1;
        if (line != -1)
        {
            Console.Write("  Colonne: ");
            column = AskPos(maxY);
        }
    } while (line == -1 || column == -1);

    return game.Plateau[line, column];
}
static Case AskCaseWithPiece(int maxX, int maxY, Game game)
{
    int line;
    int column;
    do
    {
        Console.Write("  Ligne: ");
        line = AskPos(maxX);
        column = -1;
        if (line != -1)
        {
            Console.Write("  Colonne: ");
            column = AskPos(maxY);
            if (column != -1)
            {
                if (game.Plateau[line, column].Onthis.HasValue)
                {
                    if (game.Plateau[line, column].Onthis.Value.Proprietaire != game.JoueurCourant)
                    {
                        line = -1;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Veuillez sélectionner une case avec une pièce.");
                    Console.ForegroundColor = ConsoleColor.White;
                    line = -1;
                }
            }
        }
    } while (line == -1 || column == -1);

    return game.Plateau[line, column];
}
static Case[] MovePiece(int maxX, int maxY, Game game)
{
    Console.WriteLine("Quelle pièce voulez-vous bouger ?");
    Case startingCase = AskCaseWithPiece(maxX, maxY, game);
    if (startingCase == null)
    {
        Console.WriteLine("Veuillez sélectionner une case avec une pièce.");
        return null;
    }

    Console.WriteLine("Où voulez-vous mettre la pièce ?");
    Case endingCase = AskCase(maxX, maxY, game);
    if (endingCase == null)
    {
        Console.WriteLine("Veuillez sélectionner une case.");
        return null;
    }

    Case[] cases = [startingCase, endingCase];
    return cases;
}
static Case[] Game_OnAskMooveHuman(int maxX, int maxY, Game game)
{
    return MovePiece(maxX, maxY, game);
}

IRegles ChooseRegle()
{
    while (true)
    {
        displayTitre();
        Console.WriteLine("Quelle régles voulez-vous prendre pour votre partie ?\n   0: Original\n   1: Variente");
        int answer = AskPos(1);
        if (answer == 0)
        {
            return new regleOrigin();
        }
        else if (answer == 1)
        {
            return new regleVariente();
        }
    }
}

Game ChooseGame()
{
    displayTitre();
    Console.WriteLine("Quelle partie voulez vous faire?\n   0: Joueur Vs Joueur\n   1: Random Vs Random");
    while (true)
    {
        int answer = AskPos(1);
        if (answer == 0)
        {
            Console.Clear();
            IRegles regle = ChooseRegle();
            displayTitre();
            Console.Write("Nom du joueur 1: ");
            string j1 = Console.ReadLine()!;
            Console.Write("Nom du joueur 2: ");
            Game game = new Game(regle, new HumainJoueur(j1,1), new HumainJoueur(Console.ReadLine()!,2));
            game.AskMoove += Game_OnAskMooveHuman;
            return game;
        }
        else if (answer == 1)
        {
            Game game = new Game(new regleOrigin(), new RandomJoueur("Robot 1", 1), new RandomJoueur("Robot 2", 2));
            game.AskMoove += Game_OnAskMooveAI;
            return game;
        }
    }
}

void main()
{
    Game game = ChooseGame();
    game.BoardChanged += Game_OnBoardChanged;
    game.PieceMoved += Game_OnPieceMoved;
    game.PlayerChanged += Game_OnPlayerChanged;
    game.GameOver += Game_OnGameOver;
    game.LuiAppartient += Game_OnAppartient;

    Console.Clear();
    affichePlateau(game.Plateau.echequier);
    game.Start();
}

void main2()
{
    IPersistanceManager save = new XMLPersist();
    List<Game> games = new List<Game>();
    games = save.LoadGame();
    
    Game game = games[0];
    game.AskMoove += Game_OnAskMooveHuman;
    game.BoardChanged += Game_OnBoardChanged;
    game.PieceMoved += Game_OnPieceMoved;
    game.PlayerChanged += Game_OnPlayerChanged;
    game.GameOver += Game_OnGameOver;
    game.LuiAppartient += Game_OnAppartient;

    Console.Clear();
    affichePlateau(game.Plateau.echequier);

    game.Start();
}

// main();
main2();

void testPersistance()
{
    IPersistanceManager XMLPersist = new XMLPersist();
    List<Game> games = new List<Game>();
    Game g1 = new Game(new regleOrigin(), new HumainJoueur("Unknow", 1), new HumainJoueur("Toto", 2));
    games.Add(g1);
    XMLPersist.SaveGame(games);
    Console.WriteLine("[DEBUG] => END");
}

// testPersistance();
