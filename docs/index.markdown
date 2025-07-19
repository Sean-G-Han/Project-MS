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

![UML Diagram](https://plantuml-server.kkeisuke.dev/svg/VP7B3e8m44Nt_Oe96r-1nArXWGjZs1W3Nr1XZ4rAIzhHX2Z_Rdae18chTkuzlPEPHfQueNiX6Lj0h0ZDbMTecVXS8KwGv_mYCIqHStWoWCqHgQsMArQFqOCYGTK-SmbMco_RoGvsPJegwwPfWfAJqChUH6bPvwN42Roj1xw_RizEXXraMX4NoaBOepFOIUVeK8CgHpEGhJocpv9NQ5AfoT65Vc33iicyuIi8-jm_LfCzQmyzNF9aFJ_lv_nnGEGcSb_r1W00.svg)


# EntityStat

# Entity

# EntityNode

# PlayerSlot

# TurnManager