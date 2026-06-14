# Bomb Game

Eine moderne Umsetzung eines Minesweeper-inspirierten Spiels in C# mit Windows Forms, inklusive Explosionseffekten, Timer-System und Highscore-Funktion.

---

## Über das Projekt

Das **Bomb Game** ist ein interaktives Raster-Spiel, das auf dem klassischen Minesweeper-Prinzip basiert. Ziel ist es, alle sicheren Felder aufzudecken, ohne eine Bombe zu treffen.

Das Projekt wurde komplett in **C# Windows Forms** entwickelt und fokussiert sich auf dynamische UI-Erstellung, Event-basierte Spiellogik und visuelle Effekte wie Explosionen und Partikelanimationen.

Jedes Spielfeld wird zur Laufzeit als Panel erzeugt. Bomben werden zufällig verteilt, und jede Interaktion des Spielers wird direkt über Events verarbeitet.

---

## Funktionen

- **Dynamisches Spielfeld** – Das 8x8 Raster wird vollständig zur Laufzeit generiert  
- **Zufällige Bombenverteilung** – Bomben werden ohne Überschneidung random platziert  
- **Klick-Logik** – Sichere Felder werden grün markiert, Bomben beenden das Spiel sofort  
- **Score-System** – Jeder sichere Klick erhöht den Punktestand  
- **Timer-System** – Spielzeit wird sekundengenau gezählt  
- **Highscore-System** – Beste Punktzahl wird lokal in einer Datei gespeichert  
- **Game Over System** – Bei Bombentreffer wird das komplette Spielfeld deaktiviert  
- **Neustart-Funktion** – Spiel kann direkt nach Game Over neu gestartet werden  
- **Gewinn-Erkennung** – Das Spiel erkennt automatisch, wenn alle sicheren Felder geöffnet wurden  
- **Explosionseffekt** – Bildschirm blinkt rot/schwarz bei Bombenexplosion  
- **Partikel-System** – Kleine animierte Panels simulieren Explosionseffekte  

---

## Code-Struktur & Methoden

### Spielfeld-Erstellung

- `CreateGame()`
  - Startet den kompletten Spielaufbau
  - Ruft Bombenplatzierung und Feld-Erstellung auf

- `CreateFields()`
  - Erstellt alle Panels (8x8 Grid)
  - Registriert Click-Events für jedes Feld
  - Speichert Referenzen in einem 2D Array

---

### Bombenlogik

- `PlaceBombs()`
  - Platziert Bomben zufällig im Grid
  - Verhindert doppelte Platzierung

- `bombs[,]`
  - Speichert Bombenpositionen als Boolean-Grid

---

### Spiellogik

- `ClickField(x, y, field)`
  - Hauptlogik bei jedem Klick
  - Prüft:
    - bereits geklickt?
    - Bombe oder sicher?
  - Aktualisiert Punkte oder löst Game Over aus

- `clicked[,]`
  - verhindert Mehrfachklicks auf ein Feld

---

### Timer-System

- `StartTimer()`
  - startet einen 1-Sekunden-Timer
  - erhöht die Spielzeit
  - aktualisiert UI (Points + Time)

- `gameTimer.Tick`
  - läuft dauerhaft während des Spiels

---

### Explosion & Effekte

- `Explosion(Panel bomb)`
  - aktiviert Bildschirm-Flash Effekt
  - wechselt Hintergrundfarbe rot/schwarz
  - startet Partikel-System

- `CreateParticles(Panel source)`
  - erzeugt kleine Panels als Partikel
  - bewegt sie zufällig in alle Richtungen
  - entfernt sie automatisch nach Animation

---

### Spielende & Neustart

- `GameOver()`
  - deaktiviert alle Felder
  - zeigt Dialog (Restart / Exit)
  - setzt Spielzustand zurück bei Neustart

- `CheckWin()`
  - prüft ob alle sicheren Felder geöffnet wurden
  - stoppt Timer bei Sieg

---

### Highscore-System

- `SaveScore()`
  - vergleicht aktuelle Punkte mit Highscore
  - speichert neuen Highscore in Datei (`highscore.txt`)

---

## Was ich gelernt habe

- Arbeiten mit Windows Forms Events und Panels
- Dynamische UI-Erstellung zur Laufzeit
- 2D-Arrays für Spiellogik
- Timer-basierte Game Loops
- Zufallsgenerierung ohne Überschneidungen
- Visuelle Effekte ohne Game Engine
- Dateisystemzugriff für Highscores
- Aufbau eines vollständigen Spielsystems von Grund auf

---

## Aufgabenstellung

Ziel war es, ein eigenes interaktives Spiel in C# zu entwickeln, das grundlegende Programmierkonzepte wie:

- Events
- Arrays
- Timer
- Logikstrukturen
- UI-Interaktion

kombiniert und in einem funktionierenden Spielprojekt umsetzt.

---

## Autor

**sxrg1u** – Eigenes Projekt
