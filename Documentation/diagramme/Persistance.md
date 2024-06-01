``` plantuml
@startuml
namespace DouShouQi{
   package DouShouQiLib{
     class Manager{
        + IPersistanceManager persistance
     }
     class IPersistanceManager{
        SaveData(Game game)
        LoadData()
     }
   }

   package StubPackage{
      class Stub{
        SaveData(Game game)
        LoadData()
      }
   }

   package DataContractPersist{
      class XMLPersist{
        SaveData(Game game)
        LoadData()
      }

      class JSONPersist{
        SaveData(Game game)
        LoadData()
      }

      class BINARYPersist{
        SaveData(Game game)
        LoadData()
      }
   }

   package AppDouShouQi{
      package Application{
      }
   }

   package DouShouQiConsole{
      class Program{
      }
   }
}


IPersistanceManager --> "+ persistance" Manager
XMLPersist ..|> IPersistanceManager
JSONPersist ..|> IPersistanceManager
BINARYPersist ..|> IPersistanceManager
Stub ..|> IPersistanceManager

Application ..> XMLPersist
Application ..> JSONPersist 
Application ..> BINARYPersist 
Application ..> Stub

IPersistanceManager ..> Program

Manager --> "+ TheMgr" Application
@enduml
```