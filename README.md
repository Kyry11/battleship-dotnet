# Battleship State Tracker

## App has to allow to:

- Create a board
- Add a battleship to the board
- Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss
- Return whether the player has lost the game yet (i.e. all battleships are sunk)

## Game rules:

A battleship is sunk if it has been hit on all the squares it occupies\
A player wins if all of their opponent’s battleships have been sunk

## System Requirements

1. Install [.NET Core SDK](https://dotnet.microsoft.com/download)
2. Install [Visual Studio Code](https://code.visualstudio.com/)
3. Open this project in VS Code and accept the prompt to install recommended extensions

## Installation and Startup

```
git clone https://github.com/VivekRajagopal/battleship-dotnet
cd battleship-dotnet
dotnet run
```

**Test:** `dotnet test`

## Usage

The program uses the CLI for user input. Add ships, attack and check the game win state by using commands and parameters as shown below.

### Commands:
| Command | Params | Description | Message |
| ------- | ------ | ----------- | ------- |
| `render` | | Simple rendering of the current state of the board cells |  |
| `addship right` | `left top length` | Add ship going `right` starting at `left` & `top` for `length` | `True` or `False` for ship addition |
| `addship down` | `left top length` | Add ship going `down` starting at `left` & `top` for `length` | `True` or `False` for ship addition |
| `attack` | `left top` | Attacks at `left` & `top` for `length` | `hit` or `miss` |
| `exit` / `quit` / `goodbye`| | Exits program | |
