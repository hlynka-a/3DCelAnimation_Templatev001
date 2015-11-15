3DCelAnimation_Templatev001

- made with Unity3D 5.2.0f3 Personal Edition
- made November 14, 2015



- this is an example Unity3D project that showcases a template gameobject and script for using "3D Cel Animation."
- "3D Cel Animation" is a term coined by Andrew Hlynka to describe using traditional (cel or 2D) animation in a 3D space, mainly for the purpose of implementing 2D animation into 3D games. It involves drawing and animating many perspectives of the character/object, and using a game engine to determine which perspective to make visible.
- as of 2015, see two games that make use of this technique: "Drew and the Floating Labyrinth" and "Unfinished - An Artist's Lament" for Windows PC, Mac and linux.
- this project is free for personal and professional use, no credit is required for use. But please let me know what you make, I'd love to see it!



- included is:
	- a scene file with example of how to make a certain perspective visible
	- a prefab of the gameobject with 114 frames placed around a center
	- a script to determine which perspective to make visible, called "VisibleFrame.cs"
	- additional scripts and materials to help showcase the scene file



- what you must add:
	- draw and animate all the frames you intend to use. (be warned, this can take a lot of time. Consider how long it could take you to draw 114 frames for a object with no movement, then consider how to multiply that for basic animation. From experience, I estimate approximately 60 frames per full-day can be drawn, but this can vary based on the artist.)
	- script a "AnimationManager" to update the frames in each perspective based on movement or action. It's easiest to do this separately from "VisibleFrame.cs." You may also wish to optimize this by not updating all frames at the same time.
	- update the gameobject's physics as required to meet your game's needs. This may affect the animation of your frames, but otherwise the frames should be separate from any gameplay considerations.



- considerations:
	- you do not need to use all 114 frames. Delete or disable half of them, and the result will still be effective. For the work required and the output achieved, there should be no reason to include more than 114 frames.
	- instead of a flat "VisibleFrame," consider importing a curved surface from external modeling software to replace it. This would provide better shading details on your textures. Or else consider using "unlit" shaders to ignore shading entirely. 
	- you can modulize a character's body with multiple frame-spheres. Place two or more spheres in the same position, and you can separate their rotational logic and reduce drawn frames (at expense of using more memory). Or you could attach smaller frame-spheres to a 3D skeleton to combine traditional and computer animation.
	- this is an experimental concept, and there are many un-explored improvements to this method. Please experiment to create the visuals you require.



See http://www.fromdustscratch.com for more details.