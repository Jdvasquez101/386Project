Unity consists of scenes containing game objects, which are composed from multiple components.
This folder contains two scenes: Begin, and End. The steps below will help demonstrate some of this common functionality.

1. Open the scene "01 - Begin"
2. Go to "File > Save As", then select a location and name for your version
 -Note: we could just save the scene normally, but this will overwrite the "begin" state
3. Select the "Main Camera" GameObject
4. Drag and drop "CameraFollow" from the activity folder onto Main Camera's inspector view (or onto Main Camera's entry in the scene hierarchy)
5. Select "Circle" as the target for your CameraFollow script. This can be done with the selection button, or by dragging and dropping Circle from the hierarchy menu to the target field.
6. Add "CustomScriptExample" to the "Circle" GameObject
7. Change the color, scale, and z-level fields and observe how the change

Play around with the scene and components, and note how changes you make are reflected when the scene is executed. Values can be manipulated while the scene is running, but changes are discarded. Observe the included scripts for more details. Note that CustomScriptExample only applies its values in Start(), meaning changes during runtime will have no effect.

Suggestion: Try to add some functionality to the Something function, like using transform.Translate. How does this behave when the game is being played, compared to when it is used in edit mode?
Create another object and use TestScript.cs with it, or attempt to create a small script of your own that provides some functionality.
