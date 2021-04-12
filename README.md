# PvP Turn Based test

## How to balance
Balance of the game can be achieved through ScriptableObjects. 
Are located on Assets > Prefabs > Scriptable Objects.
	- Hero stats
	- Hero attacks
	- Abilities

## How to play
- As given by the assignement:
	- Player 1 moves first (bottom heroes)
	- Player 2 moves second (top heroes)
	- Players must choose/simulate their action first.
	- After both players have choose their actions, the game execute them

- To use the slingshot mechanic, you can start the drag from anywhere of the gameboard (no need to start it over a hero)

- You can play on Unity Editor & [Android](/release/latest)

Enjoy!

## Releases
[Latest version](/release/latest)

## Time Tracking
Basic Turn Management architecture: *40min*

Hero stats, including IHeroAttack & IHeroAbility + Update hero prefabs: *40min*

Hero injecting dependencies & HeroSelector: *20min*

EventDispatcher & ServiceLocator services + HeroActionsPanel + OnSelectinHero, show actions panel: *20min*

ImageBank to display actions panel properly + HeroActionSimulator: *20min*

Investigation DragHandler: *20min*

Research of angle between vectors & quaternions: *1h*

Store move command after simulation is done: *20min*

Selectable hero Gui circle + Handling all hero actions and finish turn: *20min*

Attacks simulation: *20min*

Abilities simulation: *10min*

Game actions executioner: *30min*

Update hero prefab + move action dummy: *20min*

Improved movement action using simulation values: *10min*

HeroGuiView + Updating the gui when the hero is damaged/dead: *10min*

Updated hero animator + Added HeroAnimatorController, HeroAttackController & HeroHealthController + Playing melee attack animation on command execution: *30min*

Hitting enemies on command execution + Playing attack & hit animations: *20min*

Pooling system: *10min*

Shooting the bullet + Hitting the enemy + Researching right bullet direction: *1h*

Heal ability: 15min*

Push & Pull abilities: *10min*

Fixing angle detection, arrow & hero rotation: *1h*

Fixing bullet movement: *20min*

Fixing & improving actions execution: *20min*

Results screen: *20min*

Fixed push & pull abilities: *20min*

Searching & creating some UI assets: *25min*

Fixes & improvements: *35min*

**Total Time:** 11h 30min


## Difficult parts
- The main challenge for me was the 3D physics stuff (mainly applying forces with the pertinent transform rotation).
	- Why? Because I haven't work on 3D games, although I have minimum knowledge about it. That made me spent more time on it in comparision with other tasks.
	
	Most of my experience is on Meta side: architecturing services, communication with server, integration of SDKs (ads, analytics, etc), manage user progression, etc.

## The parts you think you could do better and how
- Obviously the 3D physics related mechanics, with more and more practice.
- For faster prototyping, maybe more referencing through the Inspector instead of complex architecture for a prototype. Although I find it useful following Open-Close principle to easier extension (add abilities, attacks and heroes very easily).


## Future improvements
- Fixed some bugs (the main one is one where you can't select heroes given some edge case).
- Replay button at the end screen.
- Showing heroes attack & ability ranges.
- Add some FXs

## Other comments
- I've tried to develop a flexible architecture based on ScriptableObjects for configs and following SOLID principles (being SRP, OCP and ISP the ones with more weight for a flexible & understandable code).
	- All the team would benefir from using ScriptableObjects as is very easy to swap/modify configs. E.g: with just 2 clicks the designer could change a hero ability or attack type.

## Unity Version
2020.3.0f1
