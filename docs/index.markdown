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

# Character/Entity Architecture

Currently, the main architecture of each character is defined in the  UML diagram below. Each class is responsible for doing different things. EntityStat defines the character stats. Entity defines a character behaviour. PlayerSlot is responsible for the player's movement in the carousel-combat-system.

![UML Diagram](https://plantuml-server.kkeisuke.dev/svg/VP7B2i8m44NtynM36rzOS5jSr8MKRaJC5uHsn42Qb6GKHFrtaxPYVU0gcNlFp72PpBDqVAerm1WBm-GEiYGFwld5OcDOyMLT1jbRXrT0dEV4dJoPnbAyby4L3L4LgZj0gQNtcDlASffkRKLnrPwqP6MDFwh6GzSiM3AEbYDSB6RjsycOOcaDIsKyhdhq1nOd1zIHgSYzo5OUqZijB-I4jXpesfufil2PSdLBadxmFw-DyzD_hG4OPFzg_lA6ZLa84sxp0000.svg)

# Combat Architecture

The main combat arena is mainly split into 2 components. The first one is the `PlayerCarousel::PlayerCarousel`, which contains instances of `PlayerSlot` and is responsible for spinning the heroes around. The other is the `EnemySlot::PlayerSlot` which contains the enemy character.

![UML Diagram](https://plantuml-server.kkeisuke.dev/svg/SoWkIImgAStDuUBAJyfAJIvHS2nApKk4SG9o4YjJYvmJY_9BYrDpOAAkUQcvbS4v-IMeoa0YXfX2HfX2nfX29bnSO9iLj7HJyilpTD6jHfL4k80BLHsQTeYJ22en8gp4cB0Ie1SSKlDIW8490000.svg)

The combat logic is defined by a bunch of managers and controlllers connected together by the main manager `CombatManager`. The `CombatManager` facilititates communication between the different managers via `Godot::Signals` while also initialises the different managers. Currently, the `CombatManager` does not directly control each manager, and rely on each manager to handle syncronous logic itself. This is a design flaw that I will be working on (TODO).

![UML Diagram](https://plantuml-server.kkeisuke.dev/svg/XPBHQW9134NVvolcqHRc1qJ4iWZw80Zs1r8twk9i0adMHQJ_tbbthJiKwUFSd7jp0xDG0x6cZixj8wZwWkili0qG757ypNqsGhkEMLwGR0LKHfIxkgGoqxw7X0z1WZoWYBm_jvNYvAr_SqE6CfOVxcuyc0TbmnTynjsxTD1a6-6AiejiJtUl5I3SAAQRyclUGyajXRpXrA-fCZz_mOxw_8UEY_wYsQu7cTTCSC5amb6JmOqtXeW72_C_qGUMMdrxOaLlYVTfLwMPTHQaEfuilF3sBlLfACujaChq2Nu0.svg)

# Character/Entity

## EntityStat

The 'EntityStat' class currently only stores stats that is than read by other class.

The stats that we currently store is:

| Stat       | Description                          |
|------------|--------------------------------------|
| `Health`   | Health                               |
| `Speed`    | How fast you refresh your turn       |
| `Attack`   | How much damage you deal             |
| `Defense`  | How much less damage you take        |

## Entity

The `Entity` class consists of not only an instance of `EntityStats`, but also contain 2 `Action<>` lamdas `AttackLogic()` and `SupportLogic()` which are meant to be overriden such that each character has their own unique attack and support skills. It does not decide which skill (Attack/Support), but rather just defines them for `MoveManager` to use as appropriate.

`Entity` Consists of:

| Attributes             | Description                                                   |
|------------------------|---------------------------------------------------------------|
| `AttackLogic(Entity)`  | The `Enitity` attack skill used when it is at the backline    |
| `SupportLogic(Entity)` | The `Enitity` support skill used when it is at the backline   |
| `Stats`                | The instance of `EntityStat` that defines its stats           |

* TODO  : Add a method that can turn Godot Resources directly into `Entities`
* TODO2 : Add a sprite variable that `EntityNode` can use to render

## EntityNode

The `EntityNode` class is meant to render sprites animations and other parts of the character based on the `Enitity` class however at the moment, it does nothing.

## PlayerSlot

The `PlayerSlot` class is meant to be a container that the `PlayerCarousel` can move without directly affecting the position of the `EnitityNode` class. it also will be used to display stuff like particle effects and other stuff.