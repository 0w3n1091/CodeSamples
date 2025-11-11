# CodeSamples

To repozytorium zawiera wybrane przykłady kodu w języku C#, mające na celu zaprezentowanie jakości, stylu i podejścia do projektowania architektury systemów. Każdy moduł pełni funkcję samodzielnego fragmentu kodu, który może być wykorzystany jako baza do docelowej implementacji.

# Inventory 
Moduł przedstawia prostą, ale elastyczną implementację systemu Inventory. Został on podzielony na dwie główne części:

* Backpack — odpowiada za przechowywanie przedmiotów w plecaku

* Equipment — reprezentuje elementy aktualnie założone przez gracza.

W docelowej wersji nad warstwą Inventory powinna znajdować się klasa kontrolera, która zarządza interakcjami między Backpack a Equipment oraz definiuje reguły wymiany przedmiotów.