# WaterCubes - PI3D miniproject

![Visuals]()

## Overview of the Game

This project is a 3D game inspired by various 2D games, where a fish needs to eat smaller fish in order to grow while trying not to get eaten by the bigger fish. It is a third-person controller game where the user is  able to control a cube (player cube) through keyboard and mouse inputs, in a closed arena representing the sea. The goal of the game is to collect/eat enemy cubes that are equal or smaller in size. When the player cube has eaten a certain amount of enemy cubes it levels up and grows and is thereby able to eat even bigger enemy cubes than before. There are five levels in total. The game progressively gets harder as the enemy cubes do not disappear unless they get eaten, so if the player is not fast enough to eat the available enemy cubes and level up in time, there will inevitably become more and more enemies. 

The main parts of the game:

- Player: cube with maincamera attached. Moves vertically using the keyboard WASD or arrow keys and horizantally by holding in the space button The player can look around using inputs from the mouse. It grows when it has eaten a certain amount of cubes. Can grow a maximum of 5 times corresponding to each of the 5 levels. 
-	Enemies: cubes in 5 different sizes. Can either eat the player if it is bigger than the player or get eaten by the player if it is smaller.
-	Enemi-spawner: empty gameobject used to randomly spawn one of the 5 enemies at a random spot within a certain range. Every time an enemy is spawned the smallest of the enemies is spawn with it to ensure the player always has an enemy to eat no matter the level.
-	Arena: closed-off space representing the sea, where the player can move freely. The bottom and rocks are made using ProBuilder and the walls are cubes with a video applied to them. 
-	Canvas Pointsystem: a UI that represents the players current level and amount of points. Every time the player levels up the points are reset to zero. 
-	Scenes: There are a total of 3 scenes which are GameScene, YouLooseScene, and YouWinScene. When the player dies it switches to the YouLooseScene and when the player wins it switches to the YouWinScene. The YouWinScene and YouLooseScene both contain two buttons, one to play again and one to quit the game.

Game Features:
- The enemies are spawned randomly enhancing replayability. 
-	The difficulty of the game changes with time. 
-	The game keeps track of level and score
-	The game has a Win and Lose screen where the user is able to choose between either playing again or quit the game.  

### Running it
1. Download Unity 2022.3.4f1
2. Clone or Download the project 
3. The game requires a computer with a mouse and keyboard

### Scripts
- PlayerScript: Consists of 4 functions besides Start() and Update().
  1. PlayerSwim(): makes the player move.
  2. PlayerLook(): makes the player look.
  3. EatCube(): updates the score and checks if the player has won or if the player should level up. If the player has won it switches to the YouWinScene.
  4. Grow(): updates the player size and level and makes the player bigger.
- Enemy: Consists of 3 functions besides Start() and Update():
  1. EnemySwim(): makes the enemy move.
  2. OnCollisionEnter(): when colliding with the player it checks the size of the player and based on that it either destoys the enemy or switches to the  YouLooseScene. When colliding with a wall it changes direction.
  3. chasePlayer(): sends out a rayCast and if it detects the player the enemy follows the player.
 - EnemySpawner: Consists of 1 function besides Start(), which is SpawnEnemy and it makes sure to spawn random enemies at a random point within a certain range.
 - Meny: Consists of 2 functions besides Start()
   1. PlayGame(): loads the play game scene.
   2. QuitGame(): closes the game. 

### Models & Prefabs
- The Sea is downloaded from [Unity Asset Store](https://assetstore.unity.com/packages/tools/particles-effects/lowpoly-water-107563)
- The Bubble Particel System is downloaded from [Unity Asset Store](https://assetstore.unity.com/packages/vfx/particles/environment/jiggly-bubble-free-61236)
- The Vidoe of the fish is made by Engin Akyurt and dowloaded from [Pexels](https://www.pexels.com/video/colorful-tropical-fish-swimming-in-an-aquarium-16011847/)

| **Task**                                                                | **Time it Took (in hours)** |
|--------------------------------------------------------------------------------|------------------------------------|
|     Setting up   Unity, making a project in GitHub                             |     0.5                            |
|     Research and   conceptualization of game idea                              |     0.5                            |
|     Trying to make/Searching for   bubble particle system                      |     2                              |
|     Searching for   Vidoe of fish                                              |     1.5                            |
|     Searching for   Sea                                                        |     1.5                            |
|     Building the scene   Arena, Rockpiles, walls with vidoe                    |     4                              |
|     Player look                                                                |     2.5                            |
|     Player   movement  finding the correct speed                               |     2                              |
|     Player   grow                                                              |     1.5                            |
|     Enemy  spawner  enemy random spawners, randomizing starting position       |     1                              |
|     Enemy movement                                                             |     0.5                            |
|     Enemy chase player                                                         |     2                              |
|     Enemy OnCollision                                                          |     1                              |
|     Combining enemy and player components                                      |     2                              |
|     Making UI   menu script, elements                                          |     2                              |
|     Collisions   bugfixing error                                               |     1.5                            |
|     Playtesting  bugfixing                                                     |     1.5                            |
|     Making readme                                                              |     3                              |
|     **All**                                                                    |     **30.5**                       |

## References
- [FIRST PERSON MOVEMENT in 10 MINUTES - Unity Tutorial](https://www.youtube.com/watch?v=f473C43s8nE&t=159s)
- [3D Platformer in Unity - Score System Tutorial](https://www.youtube.com/watch?v=FmhKnU8gTI4)
- [Video Player Quick Demo | Unity Game Engine](https://www.youtube.com/watch?v=Z2VeeNOKm24) 
- [5 Minute MAIN MENU Unity Tutorial](https://www.youtube.com/watch?v=-GWjA6dixV4)
- [Unity Tutorial (2021) - Making an Enemy Spawner](https://www.youtube.com/watch?v=SELTWo1XZ0c&t=188s)
- [Chat GPT 3.5](chat.openai.com)

 
