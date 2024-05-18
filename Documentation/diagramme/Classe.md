``` plantuml
@startuml
skinparam classAttributeIconSize 0

namespace DouShouQiLib{

	Class Case {
	    - int x
	    - int y
            + Piece OnThis
            + CaseType type
	    + Case(int x, int y, CaseType type)
	}
	
	enum CaseType{
	    0: inconnue
	    1: terre
	    2: eau
	    3: piege
	    4: taniere
	} 
	
	Class Piece {
	    - Joueur Proprietaire
            + PieceType type
	    + Piece(PieceType type)
	    + Mouvement(Direction d):Case
	}
	
	enum PieceType{
	    0: inconnue
	    1: souris
	    2: chat
	    3: chien
	    4: loup
	    5: leopard
	    6: tigre
	    7: lion
	    8: elephant
	}
	
	Class Plateau{
	    - int height
	    - int width
	    - Case[,] echequier
	    - initPlateau()
	    + Plateau()
	    + Plateau(int height, int width)
	}
	
	exception MyOutOfRangeException{
	    + MyOutOfRangeException(string message)
	}
        exception NumberRulesException{
	    + NumberRulesException(string message)
	}
        
        abstract class Joueur{
            - string Identifiant           
            + Liste<Piece> Liste_Piece
            + Joueur (string identifiant)
            + appartient (Piece piece)
            + abstract Case[] ChoisirCoup(Game game)
        }

        Class RandomJoueur{
            + RandomJoueur(string identifiant)
            + appartient (Piece piece)
            + Case[] ChoisirCoup(Game game)
        }

        Class HumainJoueur{
            + HumainJoueur(string identifiant)
            + appartient (Piece piece)
            + Case[] ChoisirCoup(Game game)
        }

        interface IRegles{
            + List<Case> CoupPossible(Case caseActu, Game game);
            + void initPlateau(Game game);
            + Bool Pouvoirbouger(Case caseActu, Case caseAdja, Plateau plateau)
            + Manger(PieceType meurtrier, PieceType victime)
            + bool EstFini(Game game);
        }

        class regleOrigin{
            + List<Case> CoupPossible(Case caseActu, Game game);
            + void initPlateau(Game game);
            + Bool Pouvoirbouger(Case caseActu, Case caseAdja, Plateau plateau)
            + Manger(PieceType meurtrier, PieceType victime)
            + bool EstFini(Game game);
            + private Game PlacementAnimaux(Game game)
        }

        class regleVariente{
            + List<Case> CoupPossible(Case caseActu, Game game);
            + void initPlateau(Game game);
            + Bool Pouvoirbouger(Case caseActu, Case caseAdja, Plateau plateau)
            + Manger(PieceType meurtrier, PieceType victime)
            + bool EstFini(Game game);
            + private Game PlacementAnimaux(Game game)
        }

        class Game{
            + Plateau Plateau
            + IRegles Regle
            + Joueur Joueur1
            + Joueur Joueur2
            + Joueur JoueurCourant
            + Game(IRegles regle, Joueur joueur1, Joueur joueur2)
            + Bool MovePiece(Case caseD, Case caseA, Plateau plateau)
            + ChangePlayer()
            + Bool IsFinish()
            + Bool Appartient(Piece piece)
            + Start()
        }

Piece --> "+ Case onThis" Case
PieceType -> "+ PieceType type" Piece
CaseType --> "+ CaseType type" Case
Case ---> Plateau

Piece --> "Liste<Piece> Liste_Piece" Joueur

regleOrigin ..|> IRegles
regleVariente ..|> IRegles

RandomJoueur--|> Joueur
HumainJoueur--|> Joueur

Plateau ---> "+ Plateau Plateau" Game
Joueur ---> "+ Joueur Joueur1" Game
Joueur ---> "+ Joueur Joueur2" Game
Joueur ---> "+ Joueur JoueurCourant" Game
IRegles ---> "+ IRegles Regle" Game



}

@enduml
```
``` plantuml
@startuml
skinparam classAttributeIconSize 0

namespace Event{

        class EventArgs{
        }
        class AppartientEventArgs{
            + bool Ok
            + Joueur Proprietaire
            + AppartientEventArgs(bool ok, Joueur proprietaire)
        }
        class AskMooveEventArgs{
            + int MaxX 
            + int MaxY
            + Game Game
            + AskMooveEventArgs(int maxX, int maxY, Game game)
        }
        class BoardChangedEventArgs{
            + Plateau NewBoard
            + Case Depart
            + Case Arrivee
            + BoardChangedEventArgs(Plateau newBoard, Case depart, Case arrivee)
        }
        class GameOverEventArgs{
            + bool End
            + Joueur Winer
            + Case Where
            + GameOverEventArgs(bool end, Joueur? winer, Case? where) 
        }
        class PieceMovedEventArgs{
            + bool Ok
            + Case Depart
            + Case Arrivee
            + PieceMovedEventArgs(bool ok, Case depart, Case arrivee)
        }
        class PlayerChangedEventArgs{
            + Joueur NouveauJoueur
            + PlayerChangedEventArgs(Joueur nouveauJoueur)
        }
        class TalkToPlayerEventArgs{
            + string Message
            + TalkToPlayerEventArgs(string message)
        }

AppartientEventArgs --|> EventArgs
AskMooveEventArgs--|> EventArgs
BoardChangedEventArgs--|> EventArgs
GameOverEventArgs--|> EventArgs
PieceMovedEventArgs--|> EventArgs
PlayerChangedEventArgs--|> EventArgs
TalkToPlayerEventArgs--|> EventArgs

}
@enduml
```

Game est la classe principal, elle va servir à lancer et à jouer une partie 
Paramètres: 
Plateau : le plateau sur lequel va se jouer la partie 
Regle : La définition des règles utilisées pour la partie J
oueur1 : le premier joueur 
Joueur2 : le deuxième joueur 
JoueurCourant : Le joueur qui doit jouer
Méthodes: 
MovePiece : Permet de bouger un pièce sur le plateau 
ChangePlayer : Permet de passer le tour d'un joueur à l'autre 
Isfinish : vérifie si la partie est terminé 
Appartient : vérifie si une pièce appartient à un joueur 
Start : Permet de lancer un partie 

IRegles est une interface qui va contenir des méthodes qui servent à vérifier le bon respect des règles durant une partie. 
Elle possède seulement des méthodes abstraites. 
Méthodes: 
CoupPossible : renvoie une liste de tous les coups possibles pour un joueur 
initPlateau : met en place le plateau de jeu 
PouvoirBouge : vérifie si un coup est valide 
Manger : vérifie si une pièce peut en manger une autre 
EstFini : défini les règles de quand se termine une partie 

regleOrigin est une classe contenant l'implémentation de l'interface IRegles. 
Elle contient les vraies règles du jeu. 
CoupPossible : renvoie une liste de tous les coups possibles pour un joueur 
initPlateau : met en place le plateau de jeu 
PouvoirBouge : vérifie si un coup est valide Manger : vérifie si une pièce peut en manger une autre 
EstFini : défini les règles de quand se termine une partie 
PlacementAnimaux : permet de placer les différents animaux sur le plateau 

regleVariente est une classe contenant l'implémentation de l'interface IRegles. 
Elle contient des règles modifiées du jeu. 
CoupPossible : renvoie une liste de tous les coups possibles pour un joueur 
initPlateau : met en place le plateau de jeu 
PouvoirBouge : vérifie si un coup est valide Manger : vérifie si une pièce peut en manger une autre 
EstFini : défini les règles de quand se termine une partie 
PlacementAnimaux : permet de placer les différents animaux sur le plateau

Joueur est une classe abstraite.
Paramètres:
Identifiant : le nom d’un joueur
Liste_Piece : la liste de pièce que possède ce joueur
Méthodes:
appartient : vérifie si une pièce appartient à ce joueur
ChoisirCoup : choisit aléatoirement un coup à jouer parmis tous ceux possibles

RandomJoueur est une classe fille de Joueur.
Méthodes:
appartient : vérifie si une pièce appartient à ce joueur
ChoisirCoup : choisit aléatoirement un coup à jouer parmis tous ceux possibles

HumainJoueur est une classe fille de Joueur.
Méthodes:
appartient : vérifie si une pièce appartient à ce joueur
ChoisirCoup : ne sert pas à grand chose, car le joueur humain choisira lui même ses coups

Plateau est une classe permettant de définir un plateau sur lequel une partie se jouera
Paramètres :
height : contient la hauteur du plateau
width : contient la largeur du plateau
echequier : tableau à double entré contenant toutes les cases du plateau

Piece est une classe contenant les informations sur les différentes pièces du jeu.
Paramètres :
Proprietaire : le joueur qui possède la pièce
Type : le type de piece que c’est parmi l’énumération de PieceType
Méthodes : 
operator== : surcharge de l’opérateur == pour comparer deux pièces
operator!= : surcharge de l’opérateur =! pour comparer deux pièces

PieceType énumération de tous les animaux qu’une pièce peut être.

Case est une classe contenant les informations sur les cases composant le plateau
Paramètres : 
x  : coordonné en abscisse d’une case sur le plateau
y : coordonné en ordonné d’une case sur le plateau
Type : type d’une case parmi la liste de CaseType

CaseType énumération des différents types qu’une case peut avoir.

RandomJoueur et HumainJoueur sont tous les deux reliés à Joueur par un lien d'héritage. Joueur va être une classe abstraite qui va juste servir à définir des choses communes à ses deux enfants comme l’identifiant et les pièces que le joueur possède.

On retrouvera les mêmes associations entre les différents évènements et la classe mère EventArgs.

IRegle va être une interface qui va mettre des méthodes communes entre les différents types de règles que l’on voudra mettre en place. RegleOrigin et Reglevariante vont donc implémenter les méthodes de IRegles tout en les modifiant pour avoir deux expérience de jeu différentes.
