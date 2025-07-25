# Bread Hearts dotNet

## Modding Framework and Runtime
This repository contains a modding framework for the Kingdom Hearts games on PC and a runtime that utilises said framework.

The framework is all of the data that describes the Kingdom Hearts games, split by each game.

The runtime is an engine that connects to an instance of a Kingdom Hearts game and can run mods built using the framework.

>This has been a project out of curiousity and wanting to improve the way we mod and play Kingdom Hearts Final Mix.
>In doing so I envisage it possible to extrapolate the runtime and engine to work with other games with ease.
>
>I am intending this release to be an early alpha release as I have not worked on this project in years
>and wish the knowledge and work to be available to anyone interested in carrying the dotnet scene for Kingdom Hearts forward.
> 
> The style of this project was effectively a refactor and so all the mod scripts here are my own effort to port then Lua scripts directly into dotnet.
> 
> All mods and work within them are credited to the authors of each script, which is flagged in each mod.

##  Features
 - Load & Execute mods built against the framework on a priority based system(500ms, 1000ms, 5000ms)
 - Apply OpenKh Patches (Experimental)
 - Game flags to facilitate easy access to game parameters/objects
 - Thread safe memory access to GameFlags during script execution
 - Example Launcher utilising the runtime showcasing how to load and run mods
##  Planned Features
  - Example Launcher Features
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

