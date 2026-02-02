# first_games

This repository contains two simple console games written in C# as a learning exercise.  The main program (`Program.cs`) prompts the user to choose between **Flappy Bird** and a small **island survival** game and then runs the selected game.  Both games use a basic framework of rectangles (`TRect`) and moving text points (`MTP`) to represent objects on screen.

## Games Included

### Flappy Bird Clone

In this mode the player controls a bird that must fly between pairs of pipes scrolling from right to left.  The bird is drawn using an `MTP` object, while the pipes are represented by `TRect` rectangles.  The game loop repeatedly moves the pipes, checks for collisions and updates the score when the bird successfully passes through a gap【937743752795525†screenshot】.  The player presses a key to make the bird “flap” upward, while gravity pulls it downward.  If the bird hits a pipe or the ground, the game ends.

### Island Game

The second option is a small “island” game (named `iland` in the code).  It draws a map made of rectangles and allows the player to move around the island.  While less fully featured than the Flappy Bird clone, it demonstrates how to render simple shapes and handle keyboard input in a console environment.

## Code Structure

* **`TRect.cs`** defines a rectangle with properties for position, width, height and colour, along with methods to set and draw itself on the console【188624621155914†screenshot】.
* **`MTP.cs`** defines a moving text point class used to represent moving objects like the bird.  It holds the x/y coordinates and the character to display.
* **`Program.cs`** contains the `Main` method.  It displays a prompt asking the user to enter `0` for Flappy Bird or `1` for the island game and then calls the corresponding function【937743752795525†screenshot】.  The game loop for Flappy Bird creates random pipes, moves them across the screen and updates the bird’s position based on user input【707278586481032†screenshot】.

## Building and Running

1. Open the solution in Visual Studio or another C# IDE.
2. Ensure that the project targets .NET Framework 4.0 or later (the games use basic console features and do not depend on external libraries).
3. Build the solution and run it.  A console window will open asking you to press `0` or `1`.  Choose a game and follow the on‑screen instructions.

## Notes

These games are simple prototypes created for practice.  They do not include advanced graphics or sound but demonstrate fundamental programming concepts such as loops, conditionals, object‑oriented design and keyboard input handling.
