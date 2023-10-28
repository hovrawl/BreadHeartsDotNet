# Bread Hearts dotNet

## Modding Framework and Runtime
This repository contains a modding framework for the Kingdom Hearts games on PC and a runtime that utilises said framework.

The framework is all of the data that describes the Kingdom Hearts games, split by each game.

The runtime is an engine that connects to an instance of a Kingdom Hearts game and can run mods built using the framework.

##  Features
 - Execute mods on a priority based system(500ms, 1000ms, 5000ms)
 - Game flags to facilitate easy access to game parameters/objects
 - Thread safe memory access to GameFlags during script execution

##  Planned Features
  - Externally load scripts dynamically; Drag n Drop style (MEF/MAF)
  - Bespoke interface to utilise the runtime
      - Mod Configuration (Enable, Disable, settings)
      - Mod Presets (Rando Rules, etc.)
      - 'Tracker' interface
  - Support for KH2/KHBBS

## Game Support

| Game                                    | Supported | Notes |
|:----------------------------------------|:---------:|------:|
| Kingdom Hearts Final Mix                |     ✅     |       |
| Kingdom Hearts II Final Mix             |     ❌     |       |
| Kingdom Hearts Birth By Sleep Final Mix |     ❌     |       |

## Built in Mods

<details>

<summary>Kingdom Hearts Final Mix</summary>
    - Save Anywhere
    

</details>

