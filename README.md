## RESTWebApiCodeFirst
Projekt polega na stworzeniu aplikacji REST API w technologii ASP.NET Core z wykorzystaniem Entity Framework Core w podejściu Code First. Aplikacja umożliwia zarządzanie komputerami oraz ich komponentami i pokazuje, jak modelować relacje między tabelami, w szczególności relację wiele-do-wielu. W projekcie wykorzystano migracje oraz seedowanie danych w celu zbudowania i wypełnienia bazy danych.
## Endopinty
GET /api/pcs – pobiera listę wszystkich komputerów
GET /api/pcs/{id} – zwraca szczegóły wybranego komputera
POST /api/pcs – dodaje nowy komputer
PUT /api/pcs/{id} – aktualizuje dane komputera
DELETE /api/pcs/{id} – usuwa komputer
