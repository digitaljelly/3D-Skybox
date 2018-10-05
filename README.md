# 3D-Skybox

Just some simple scripts that allow you to create a 3D Skybox in Unity.

Installation:
  1) Simply import into your project somewhere
  2) Create an empty GameObject in your scene
  3) Add the component "Sky Box Camera" (SkyBoxCamera.cs) to that GameObject
  4) Set the layer/s that all objects in 3D Sky Box will exist on on the Sky Box Camera component (note: anything in this mask WONT be rendered by the normal Main Camera, so maybe use a new Layer just for this)
  
  If you want to use Unity Fog, you'll need to add "Fog Density" to the Sky Box Camera GameObject. You can then tweak the density settings to match what you need it to
  
TODO:
  Make a demo scene.


