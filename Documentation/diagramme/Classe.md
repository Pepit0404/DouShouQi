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

        class Manager{
            + Game Game
            + Plateau Plateau
            + IRegles Regles
            + Joueur Joueurs
            + CreateGame()
            + setRegles(string regle)
        }

        class Settings{
            + int VolumeMusic
            + string Theme
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
Settings ---> "+ Settings setting" Manager



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

Game est la classe principal, elle va servir à lancer et à jouer une partie </br>
Paramètres: </br>
Plateau : le plateau sur lequel va se jouer la partie </br>
Regle : La définition des règles utilisées pour la partie J</br>
oueur1 : le premier joueur </br>
Joueur2 : le deuxième joueur </br>
JoueurCourant : Le joueur qui doit jouer</br>
Méthodes: </br>
MovePiece : Permet de bouger un pièce sur le plateau </br>
ChangePlayer : Permet de passer le tour d'un joueur à l'autre </br>
Isfinish : vérifie si la partie est terminé </br>
Appartient : vérifie si une pièce appartient à un joueur </br>
Start : Permet de lancer un partie </br>

IRegles est une interface qui va contenir des méthodes qui servent à vérifier le bon respect des règles durant une partie. </br>
Elle possède seulement des méthodes abstraites.</br> 
Méthodes: </br>
CoupPossible : renvoie une liste de tous les coups possibles pour un joueur </br>
initPlateau : met en place le plateau de jeu </br>
PouvoirBouge : vérifie si un coup est valide </br>
Manger : vérifie si une pièce peut en manger une autre </br>
EstFini : défini les règles de quand se termine une partie </br>

regleOrigin est une classe contenant l'implémentation de l'interface IRegles. </br>
Elle contient les vraies règles du jeu. </br>
CoupPossible : renvoie une liste de tous les coups possibles pour un joueur </br>
initPlateau : met en place le plateau de jeu </br>
PouvoirBouge : vérifie si un coup est valide Manger : vérifie si une pièce peut en manger une autre </br>
EstFini : défini les règles de quand se termine une partie </br>
PlacementAnimaux : permet de placer les différents animaux sur le plateau </br>

regleVariente est une classe contenant l'implémentation de l'interface IRegles. </br>
Elle contient des règles modifiées du jeu. </br>
CoupPossible : renvoie une liste de tous les coups possibles pour un joueur </br>
initPlateau : met en place le plateau de jeu </br>
PouvoirBouge : vérifie si un coup est valide Manger : vérifie si une pièce peut en manger une autre </br>
EstFini : défini les règles de quand se termine une partie </br>
PlacementAnimaux : permet de placer les différents animaux sur le plateau</br>

Joueur est une classe abstraite.</br>
Paramètres:</br>
Identifiant : le nom d’un joueur</br>
Liste_Piece : la liste de pièce que possède ce joueur</br>
Méthodes:</br>
appartient : vérifie si une pièce appartient à ce joueur</br>
ChoisirCoup : choisit aléatoirement un coup à jouer parmis tous ceux possibles</br>

RandomJoueur est une classe fille de Joueur.</br>
Méthodes:</br>
appartient : vérifie si une pièce appartient à ce joueur</br>
ChoisirCoup : choisit aléatoirement un coup à jouer parmis tous ceux possibles</br>

HumainJoueur est une classe fille de Joueur.</br>
Méthodes:</br>
appartient : vérifie si une pièce appartient à ce joueur</br>
ChoisirCoup : ne sert pas à grand chose, car le joueur humain choisira lui même ses coups</br>

Plateau est une classe permettant de définir un plateau sur lequel une partie se jouera</br>
Paramètres :</br>
height : contient la hauteur du plateau</br>
width : contient la largeur du plateau</br>
echequier : tableau à double entré contenant toutes les cases du plateau</br>

Piece est une classe contenant les informations sur les différentes pièces du jeu.</br>
Paramètres :</br>
Proprietaire : le joueur qui possède la pièce</br>
Type : le type de piece que c’est parmi l’énumération de PieceType</br>
Méthodes : </br>
operator== : surcharge de l’opérateur == pour comparer deux pièces</br>
operator!= : surcharge de l’opérateur =! pour comparer deux pièces</br>

PieceType énumération de tous les animaux qu’une pièce peut être.</br>

Case est une classe contenant les informations sur les cases composant le plateau</br>
Paramètres : </br>
x  : coordonné en abscisse d’une case sur le plateau</br>
y : coordonné en ordonné d’une case sur le plateau</br>
Type : type d’une case parmi la liste de CaseType</br>

CaseType énumération des différents types qu’une case peut avoir.</br>

RandomJoueur et HumainJoueur sont tous les deux reliés à Joueur par un lien d'héritage. Joueur va être une classe abstraite qui va juste servir à définir des choses communes à ses deux enfants comme l’identifiant et les pièces que le joueur possède.</br>

On retrouvera les mêmes associations entre les différents évènements et la classe mère EventArgs.</br>

IRegle va être une interface qui va mettre des méthodes communes entre les différents types de règles que l’on voudra mettre en place. RegleOrigin et Reglevariante vont donc implémenter les méthodes de IRegles tout en les modifiant pour avoir deux expérience de jeu différentes.</br>
