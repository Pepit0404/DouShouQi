``` plantuml
@startuml

namespace DouShouQi{
  package DouShouQiLib{
    package Class{}
    package Event{}
    package Interface{}
  }
  package DouShouQiTest{

  }
  package AppDouShouQi{
  
  }
}

DouShouQiLib --> AppDouShouQi
DouShouQiTest --> DouShouQiLib
@enduml
```