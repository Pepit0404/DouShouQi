``` plantuml
title Daigramme de séquence simplifier

participant Game
participant Start()
participant AskMoove()
participant JoueurCourant
actor Joueur1
actor Joueur2

Game -> Start(): run Game.Start()

loop isFini() is False
    Start() -> Start() : OnGameOver(false, null, null)
    Start() -> Start(): ChangePlayer()
    
    activate Start()
    
    Start() -> JoueurCourant : OnTalkToPlayer("Quelle pièce bouger ?")
    
    Start() -> AskMoove(): 
    deactivate Start()
    activate AskMoove()
    
    loop PouvoirBouger() is true
        AskMoove() -> JoueurCourant : "position depart"
        activate JoueurCourant
        JoueurCourant -> AskMoove() : Case
        deactivate JoueurCourant

        AskMoove() -> JoueurCourant : "position arrive"

        activate JoueurCourant
        JoueurCourant -> AskMoove() : Case
        deactivate JoueurCourant
    
    end
    
    AskMoove() -> Start() : Case[]
    deactivate AskMoove()
    activate Start()
    
    Start() -> Start() : MovePiece()
end

Start() -> Start() : OnGameOver(true, JoueurCourant, null)
Start() -> Joueur1 : GameOver(true, JoueurCourant, null)
activate Joueur1
Joueur1 -> Joueur1 : Afficher message de fin de jeu
deactivate Joueur1
Start() -> Joueur2 : GameOver(true, JoueurCourant, null)
activate Joueur2
Joueur2 -> Joueur2 : Afficher message de fin de jeu
deactivate Joueur2

Start() -> Game :
deactivate Start()
```