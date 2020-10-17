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
| Jackson Hu    | Fish spawning, level selection menu      |  Done |
| Luke Hawkins    | fishing mechanics, player movement, camera movement, shaders      |  Done |
| Jessica Hammer  | sound, UI, design, particle effects     |  Done |

## Explanation of the game
This game is a 3rd-person top-down fishing game with a few different levels. The aim of the game is to catch a certain amount of fish within the time limit, and progress through the levels.

### How to use it (especially the user interface aspects)
This game is intended to be played with a keyboard and mouse. Once the main menu appears, click start to play. You can also view the instructions of the game or quit the application.

**insert photo of main menu**

Then, select which level you would like to play. At the start, only one level will be avaliable to select. The other levels become unlocked as you progress through the game.

**insert photo of level selection**

When you are in the level, it is time to start catching some fish. Keep an eye on the timer, because if not enough fish are caught by the time the clock reaches zero then you fail the level. The amount of fish that need to be caught can be seen in the top left of the screen (the number on the right), as well as the number of fish you have currently caught (the number on the left).

<p align="center">
  <img src="Gifs/In Game.png"  width="400" >
</p>

In order to catch fish you may want to move the player to get a better look at the water. Use the WASD keys to move and point with the mouse the direction you want to look at. If you are looking in the direction of a fish, then left click, hold, and release to cast the fishing rod. The longer you hold down left click the further out the line will be cast. Once the fish bites (when you hear the sound effect) then click again to pull the fish back in.

If you catch the required number of fish before the timer ends, the level completion menu will pop up. Click the 'next' button to go to the next level, or 'retry' if you want to try and beat your record.

**insert photo of level completion**

### How objects and entities were modelled
Overall, our vision for the aesthetic of the game was a simple cartoony style. We decided to stick to a low poly style as best as we could, since it has the potential to look really good and it is not as taxing on the computer (due to smaller vertex counts). Furthermore, if certain assets we wanted were not avaliable online then modelling our own (with unfortunately limited artistic skills) was an option because of the simplicity of the style. 

The following objects were modelled (by Jess) from scratch in Blender: The fish, the player, the fishing rod, and the island shape.

<p align="center">
  <img src="Gifs/Player.png"  width="300" >
</p>
<p align="center">
  <img src="Gifs/Fish.png"  width="300" >
</p>
<p align="center">
  <img src="Gifs/Island.png"  width="300" >
</p>

The modelling process for these objects began with creating primitive meshes in blender such as cylinders, planes and spheres. They were then sculpted into the desired shape using Blender's intuitive sculpting tools. The final trick to making the models low-poly was to apply the 'Decimate' modifier. This removes some amount of verticies and condenses the mesh into simpler shapes. The models were then exported out of blender as a .fbx and imported into Unity. Since .fbx files contain material data as well, the colours of the models could then be adjusted in Unity as desired by modifying the material colour for each mesh. We decided to go with very natural colours like brown, green and blue because not only is our game set outdoors in nature, but those colours are also calming to look at. 

The lighting was another important factor that helped to tie objects in the whole scene together. By setting the ambient light to a light pink colour, this got rid of muddy shadows and gave the screen a slight cool tint. A directional light in each scene helped provide some soft shadows for a bit of extra detail.

The water, sadly, was one of the exeptions to the low poly aesthetic because we could not get crisp, hard edges without using the **i forgot what it is called** shader, which is not supported on some Macs. 

The rest of the main assets (skybox, trees, grass, shells, font) were from the asset store (see references) and were chosen primarily because of their simple, low-poly style and nice colours. 

**insert photo of island here**

We also made our own panels for the UI since we wanted the buttons to have a round shape which feels more natural. We chose to stick with a brown theme for the UI since is is a neutral colour that is found alot in nature.

**insert picture of the UI**

The sound effects/music were mostly sourced from the internet (see references) post-processing adjustments made in Logic Pro. It was often the case where sound clips had to be spliced, faded out or combined to produce the final result. Reverb, spread and equalisation was also sometimes added. A few sound effects (fish collection sound, level completion sound) were made from scratch. We tried to keep the sound effects sounding natural, avoiding synth, electronic sounds. 

**maybe talk about the particle effects????????**

### How the graphics pipeline and camera motion was handled

## Camera motion

## Graphics pipeline
**explain why the things we have are done at the right stages**

### How the shaders work
The fish wiggle shader displaces the vertices of the fish to make it look like it is swimming. This is done by using `_Time` in a sin function. It was parametrised to take a speed, intensity and frequency value for the movement. **explain why using GPU was better than CPU**

<p align="center">
  <img src="Gifs/Fish Wiggle.gif"  width="300" >
</p>

## Querying and evaluation
Description of the querying and observational methods used, including: description of the participants (how many, demographics), description of the methodology (which techniques did you use, what did you have participants do, how did you record the data), and feedback gathered.

Document the changes made to your game based on the information collected during the evaluation.
	
## Technologies
Project is created with:
* Unity 2019.4.3f1

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
Rocks from: Low Poly Rock Pack by Broken Vector, Unity Asset Store\
Trees (and a skybox): POLY STYLE Vegetation Pack by Singularity Art Studio, Unity Asset Store\
Grass, small rocks from: Simplistic low poly nature by Acorn Bringer, Unity Asset Store\
Skybox from: Customizable skybox by Key Mouse, Unity Asset Store\
Main font used from: Bubble font (free version) by Jazz Create Games, Unity Asset Store\

### Sound effects
Fishing cast: https://www.youtube.com/watch?v=pjHdbABLkTY and https://www.youtube.com/watch?v=mD58V881Jdk combined together\
Beach ambience: https://freesound.org/people/inchadney/sounds/66046/ \
Crickets: https://freesound.org/people/reinsamba/sounds/58235/ \
Menu music: https://soundimage.org/quiet-peaceful-mellow/ Key West Sunset\
UI SFX: https://soundimage.org/sfx-ui/ \
Collect fish sound: Tune made in Logic Pro by Jess and https://freesound.org/people/InspectorJ/sounds/421184/ combined together\
Fish bite sound: https://freesound.org/people/InspectorJ/sounds/398711/ and https://freesound.org/people/qubodup/sounds/210426/ \
Splash: https://freesound.org/people/InspectorJ/sounds/416710/ \
Level fail tune: https://freesound.org/people/florianreichelt/sounds/412427/ \

### Code/Scripts
Camera depth of focus/vignette shader effect from: POLY STYLE Vegetation Pack by Singularity Art Studio, Unity Asset Store


