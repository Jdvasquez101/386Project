You have been provided assets that will let you push Unity to its performance limits for your machine.
This will be used for you to test with the profiler, and observe how different decisions can impact performance.
It is worth noting that Unity 6 has improved the capabilities of the Profiler, so you may benefit from trying this in Unity 6 instead/in addition to Unity 2022

If you are using VS code and have the official Unity extension installed, you can Debug your Unity code in real time. This is the only way we can (sometimes!) diagnose/end an infinite loop reached in the course of gameplay.
-Check that VS Code is being used as Unity's Code Editor
-Ensure the Unity Extension is installed
-Open your desired project in both Unity and VS Code 
-"Show and Run Commands" with the top command bar or Ctrl+Shift+P
-Select "Attach Unity Debugger", then select the relevant process
You can now pause execution, set breakpoints, and observe local/watched variables. Note that the Unity editor will be nonresponsive while execution is paused.

Factors to test:
-Amount of objects
-Resolution of art assets
-Complicated interactions

This package requires the following packages to properly import:
-Unity UI
-Input System
