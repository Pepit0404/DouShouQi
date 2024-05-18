``` plantuml
@startuml

namespace DouShouQi{
  package DouShouQiLib{
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