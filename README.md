# CodeSamples (Polish)

To repozytorium zawiera wybrane przykłady kodu w języku C#, mające na celu zaprezentowanie jakości, stylu i podejścia do projektowania architektury systemów. Każdy moduł pełni funkcję samodzielnego fragmentu kodu, który może być wykorzystany jako baza do docelowej implementacji.

# Inventory 
Moduł przedstawia prostą, ale elastyczną implementację systemu Inventory. Został on podzielony na dwie główne części:

* Backpack — odpowiada za przechowywanie przedmiotów w plecaku

* Equipment — reprezentuje elementy aktualnie założone przez gracza.

W docelowej wersji nad warstwą Inventory powinna znajdować się klasa kontrolera, która zarządza interakcjami między Backpack a Equipment oraz definiuje reguły wymiany przedmiotów.


# CodeSamples (English)
This repository contains selected C# code samples designed to demonstrate code quality, coding style, and architectural design principles. Each module functions as a self-contained code snippet that can serve as a foundation for production-ready implementations.

## Inventory
This module showcases a simple yet flexible implementation of an Inventory System. It is divided into two primary components:

* Backpack: Manages item storage within the player's bag.

* Equipment: Represents the items currently equipped by the player.

In a final implementation, a Controller layer should sit above the Inventory modules. This controller would manage interactions between the Backpack and Equipment and define the business rules for item swapping and validation.
