Selected notes:

-The draw order of UI objects directly depends on their order within the hierarchy, unlike gameobjects

-Rescaling/resizing UI elements is dependent upon their anchor (switch healthbar-fill's anchor to x=0.5 to see what that can look like)

-Object Pooling is a way to reuse objects that are created and destroyed regularly to avoid garbage collection calls, improving performance

-The Canvas object being used for a healthbar is in world space, which is more appropriate for items associated with world objects

-UnitPool implements Unity's ObjectPool, https://docs.unity3d.com/2021.1/Documentation/ScriptReference/Pool.ObjectPool_1.html

Todos:

-How could we modify the enemymanager to spawn enemies in a more desirable manner? What if we wanted enemies to spawn around the player? What if we wanted them to spawn off-screen?

-What other actions could we take when the player dies? (hints: Time.timeScale, reloading the scene)
