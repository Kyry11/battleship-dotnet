[Forked from FlareHR battleship-dotnet take-home exercise](https://github.com/flarehr/battleship-dotnet)

# Battleship State Tracker

## System Requirements

1. Install [.NET Core SDK](https://dotnet.microsoft.com/download)
2. Install [Visual Studio Code](https://code.visualstudio.com/)
3. Open this project in VS Code and accept the prompt to install recommended extensions

## Installation and Startup

```
git clone https://github.com/VivekRajagopal/battleship-dotnet`
dotnet run
```

## Usage

The program uses the CLI for user input. Add ships, attack and check the game win state by using commands and parameters as shown below.

### Commands:
| Command | Params | Description | Message |
| ------- | ------ | ----------- | ------- |
| `render-board` | `none` | Simple rendering of the current state of the board cells | `none` |
| `addship` | `right|down left top length` | Add ship going `right` or `down` starting at `left` & `top` for `length` | `True` or `False` for ship addition |
| `attack` | `left top` | Attacks at `left` & `top` for `length` | `hit` or `miss` |
| `exit | quit` | `none` | Exits program | `none` |
