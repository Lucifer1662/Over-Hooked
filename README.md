**The University of Melbourne**
# COMP30019 – Graphics and Interaction

Final Electronic Submission (project): **4pm, Fri. 6 November**

Do not forget **One member** of your group must submit a text file to the LMS (Canvas) by the due date which includes the commit ID of your final submission.

You can add a link to your Gameplay Video here but you must have already submit it by **4pm, Sun. 25 October**

# Project-2 README

## Table of contents
* [Team Members](#team-members)
* [Explanation of the game](#explanation-of-the-game)
* [Querying and evaluation](#querying-and-evaluation)
* [Technologies](#technologies)
* [Using Images](#using-images)
* [Code Snipets ](#code-snippets)
* [References](#references)

## Team Members

| Name | Tasks | State |
| :---         |     :---:      |          ---: |
| Xiaochen Hou    | Fish movement      |  Done |
| Jackson Hu    | Fish spawning      |  Done |
| Luke Hawkins    | fishing mechanics, player movement, camera movement, shaders      |  Done |
| Jessica Hammer  | sound, UI, design, particle effects     |  Done |

## Explanation of the game
This game is a 3rd-person top-down fishing game with a few different levels. The aim of the game is to catch a certain amount of fish within the time limit.

### How to use it (especially the user interface aspects)
This game should be played with a keyboard and mouse. Standard WASD player movement and move mouse to look around. Left click, hold, and release to cast the fishing rod.

### How objects and entities were modelled
Objects and entites were modelled by using assets from the asset store and also by making our own in blender. Then the appropriate materials and sizing were set in Unity. 

### How the graphics pipeline and camera motion was handled

### How the shaders work
The fish wiggle shader displaces the vertices of the fish sideways by using Time in a sin function. It was parametrised to take a speed, intensity and frequency value for the movement.

## Querying and evaluation
Description of the querying and observational methods used, including: description of the participants (how many, demographics), description of the methodology (which techniques did you use, what did you have participants do, how did you record the data), and feedback gathered.

Document the changes made to your game based on the information collected during the evaluation.
	
## Technologies
Project is created with:
* Unity 2019.4.3f1
* Ipsum version: 2.33
* Ament library version: 999

## Using Images

You can use images/gif by adding them to a folder in your repo:

<p align="center">
  <img src="Gifs/Q1-1.gif"  width="300" >
</p>

To create a gif from a video you can follow this [link](https://ezgif.com/video-to-gif/ezgif-6-55f4b3b086d4.mov).

## Code Snippets 

You can include a code snippet here, but make sure to explain it! 
Do not just copy all your code, only explain the important parts.

```c#
public class firstPersonController : MonoBehaviour
{
    //This function run once when Unity is in Play
     void Start ()
    {
      standMotion();
    }
}
```
## References

### Models
Rocks from: Low Poly Rock Pack by Broken Vector, Unity Asset Store
Trees: POLY STYLE Vegetation Pack by Singularity Art Studio, Unity Asset Store
Grass, small rocks from: Simplistic low poly nature by Acorn Bringer, Unity Asset Store
Skybox from: Customizable skybox by Key Mouse, Unity Asset Store
Main font used from: Bubble font (free version) by Jazz Create Games, Unity Asset Store

### Sound effects
Fishing cast: https://www.youtube.com/watch?v=pjHdbABLkTY and https://www.youtube.com/watch?v=mD58V881Jdk
Beach ambience: https://freesound.org/people/inchadney/sounds/66046/
Menu music: https://soundimage.org/quiet-peaceful-mellow/ Key West Sunset
UI SFX: https://soundimage.org/sfx-ui/
Collect fish sound: https://freesound.org/people/Wagna/sounds/325805/ and https://freesound.org/people/InspectorJ/sounds/421184/
Chomp: https://www.youtube.com/watch?v=Zm7Sbb9bzi8
Splash: https://freesound.org/people/InspectorJ/sounds/416710/

### Code/Scripts
Camera depth of focus/vignette shader effect from: POLY STYLE Vegetation Pack by Singularity Art Studio, Unity Asset Store


