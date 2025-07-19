---
# Feel free to add content and custom Front Matter to this file.
# To modify the layout, see https://jekyllrb.com/docs/themes/#overriding-theme-defaults

layout: home
title: Developer Guide
date: 2025-07-13
---
# Welcome to Project-MS
This website serves 2 purpose, as the technical documentation for Project-MS, covering architecture, classes, and workflows and also to document some design considerations (although much less). I will try my best to update this page as much as possible.

# Design Idea

One challenge facing many mobile JRPGs is control. Mobile inputs are often imprecise and quite jank, with buttons often being too small and virtual joysticks being too prone to misinputs. Some games like the WitchSpring series try to fix this by having touch-and-move (not sure if that's the name) overworld movement.

However, where this limitations become really apparent however, is combat, with many games opting for turn-based/autobattler formats. Some games like Genshin are action, but are admittedly much more fun to play on other platforms.

The solution project-MS proposed is to use an autobatler hybrid with gesture-controls elements (like Fruit Ninja) to form a 'carousel' combat system. Essentially, there will be 4 heroes and 1 enemy where the players can rotate their formation by swiping the screen left or right. 

![img](images/GeneralGamePremise.png)

Characters in front will perform their attack skills on the enemy while also taking attacks from the enemy. Meanwhile, the characters at the back will perform support skills like buffs or heals. The turn order is determined by a turn bar.

![img](images/GeneralGameFlow.png)

# Architecture

Currently, the main architecture of each character is defined in the  UML diagram below. Each class is responsible for doing different things. EntityStat defines the character stats. Entity defines a character behaviour. PlayerSlot is responsible for the player's movement in the carousel-combat-system.

![UML Diagram](https://www.plantuml.com/plantuml/png/TP312i8m44Jl-Ogb9nLQy5fww4MyYTWlM9iH2caYoIeK_7XhMIm1lIKpRsUPRPDmbCVepE05ySOzw0AsV7Nexe0rlUEKwE1baAaJbap8FgTWeSBPyOJOkI36hADKx0lQbQNoL5CVlF3W4pMAvSWIEMCHtY8gfVANN7VDv1YU-70cAq7Dgweqye-ZgJ_Sh4nkrtI4BC_DrhJmTZxa6m00)


# EntityStat

# Entity

# EntityNode

# PlayerSlot

# TurnManager