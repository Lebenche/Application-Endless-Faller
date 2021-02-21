# Project Review

## Lenny Bencherif

---


<!-- Your review goes here -->
<!-- Explain why you did the things that way or any snippet that is word mentioning -->
<!-- If you had any issue and how you resolved them -->
It was an interesting project. I learnt new things and I have to manage some issues that I never encountered before. Globally I think I spent around 7 hours on the project. These hours were dispatched during the last 4 days mostly. 

Review

- When I cloned the project I noticed that the movement of the player were defined with Transform.Translate. It worked but the movement weren't smooth and as a player it could be frustrating. So to enhance that I used AddForce method which was used through the character's rigidBody. I added ForceMode.Impulse parameter to add this "push feeling". I think that with this the user experience is a little bit better. 

- About using another thing than PlayerPref for store the High score I immediately thought about store it in a XML file. During my previous professional experience we were used to use XML file to store texts content. It was easy for me to read a value in a XML file however it was more complicated to modify one (when the player make a higher score). So I made some research to how serialize an XML file and I finally did something that work. This solution works well, nevertheless I'm not totally comfortable with serialization and you will see that my XML file is very basic due to this. 

- About the structure of my code I tried, as much as I can, to have separate classes with single responsibility.

- I almost implemented all the features required however I encountered too much difficulties on the Spawn rate implementation. The main reason is because instead of destroying and Instantiate platforms I teleport them at the bottom of the level. With this way it was more complicated and confusing to implement a spawn rate. I should implement destroy/Instantiate method but the time was running out and I preferred to let the code like it was instead of rewriting everything at the last moment. You will see that I still added the functionality which allows to read the spawn rate value on an XML file (config.xml)

- To make the game prettier I used Post processing effect. Upgraded the project by using URP for implement in an easiest way post processing. I added chromatic aberration and Blooming effect to be close to the "retro wave" vibe like we saw in "Stranger things" and other stuffs like that. I finally added emission material to reinforce this aspect.

- On the optimization side I defined as static 3d objects that don't move for the static batching. On my script I deleted the empty Update method because even if they're empty they trigger the Garbage collector for nothing. I also take care about put if conditions inside Update t avoid call other methods inside every frame. 
source for optimization : https://learn.unity.com/tutorial/fixing-performance-problems#5c7f8528edbc2a002053b594  
About coding optimization I noticed that I used a lot of if conditions inside my Update methods. I think it can be enhanced it by, instead, using Event system which are triggered only once and not during each frame after the conditions have been filled. I decided to not work with Event for this project because I am not mastering them yet however I am going to focus on it on the coming days. 

To conclude I liked this project because I enjoy to be not only in coding but also be involved in user experience, optimization, enhancing graphics and that's why I really like to work with Unity.

NOTE1 : I noticed you changed the Unity's version to use however as I started to work on the project I didn't wanted to use another version as the deadline was closed. 

NOTE2 : The XML files need to be inside the BUILD file but I already insert inside 

NOTE3 : If you take a look at the "Home" scene you will notice there is 3 cube with various materials. I put them because, when I first tried to make a Build materials with emission didn't render correctly in "Game" scene. 