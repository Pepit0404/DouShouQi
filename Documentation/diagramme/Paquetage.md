``` plantuml
@startuml

namespace DouShouQi{
  package DouShouQiLib{
    class Class
    class Event
    class Interface
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