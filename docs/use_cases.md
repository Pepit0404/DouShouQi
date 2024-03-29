# Use cases

``` plantuml
@startuml
left to right direction
actor "Utilisateur" as j
rectangle Dou_Shou_Qi{
  usecase "Lancer une partie" as UC1
  usecase "Charger une partie" as UC2
  usecase "Regarder les crédit" as UC3
  usecase "Regarder le tableau des Scores" as UC4
  usecase "Changer options" as UC8
  usecase "Activer/Désactiver son" as UC9
  usecase "Changer thème" as UC10
  usecase "Entrer noms des joueurs" as UC5
  usecase "Activer règle" as UC6
  usecase "Jouer" as UC7
  usecase "Importer joueur" as UC11
  usecase "Sauvegarder la partie" as UC12
  usecase "Quitter la partie" as UC13
  
}
j-- UC1
j-- UC2
j-- UC3
j-- UC4
j-- UC8
UC1 ---|> UC5 
UC1 ---|> UC11 
UC1 <... UC6 : <extend>
UC5 ...> UC7 : <include>
UC2 ....> UC7 : <include>
UC11 ...> UC7 : <include>
UC8 --|> UC9 
UC8 --|> UC10
UC7 --|> UC12
UC7 --|> UC13
@enduml
```

| USE CASE | Lancer une partie |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Charger une partie |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Regarder les crédit |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Regarder le tableau des Scores |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Changer options |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Activer/Désactiver son |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Changer thème |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Entrer noms des joueurs |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Importer joueur |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Activer règle |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Jouer |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Sauvegarder la partie |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Quitter la partie |
| :----------- |:----------------- |
| Objectif | afzaev |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |