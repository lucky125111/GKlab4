# Unity sharders in bowling game
The purpose of this project was to implement different shaders in unity. Additionally a not very pretty bowling game was created.

## Shaders

You can check the implementation in folder`unityshaders/Bowling/Assets/Shaders/`

1. Phong Blinn [[wiki]](https://en.wikipedia.org/wiki/Gouraud_shading)
![https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/PhongBlinn.png](https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/PhongBlinn.png)
2. Gouraud Blinn [[wiki]](https://en.wikipedia.org/wiki/Gouraud_shading)
![https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/GouraudBlinn.png](https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/GouraudBlinn.png)
3. Phong - constant
![https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/ConstantPhongRectangle.png](https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/ConstantPhongRectangle.png)
5. Blinn - constant
![https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/ConstBlinn.png](https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/ConstBlinn.png)
6. Gouraud Phong - mix
![https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/GourardPhong.png](https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/GourardPhong.png)
7. Static shader
![https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/Static.png](https://raw.githubusercontent.com/lucky125111/UnityShaders/master/Images/Static.png)

### Switching shaders in "game"
* q - Phong (rectangle) 
* w - Blinn (rectangle) 
* e - GouraudBlinn 
* r - GouraudPhong 
* t - PhongBlinn 
* y - Phong 
* u - Static 
* i - Phong (triangle)

## Demo

![Demo](https://github.com/lucky125111/UnityShaders/blob/master/Bowling.gif?raw=true)

Did I mentioned the game isn't very pretty? :) 

## Game controls
Let's say you really want to play this animation game. Here's the controls:
* Space - roll the ball
* r - reset
* a,d - move ball left and right
* 1,2,3,4,5 - switch cameras, camera 5 is movable by arrow keys and arrow keys+left mouse button
