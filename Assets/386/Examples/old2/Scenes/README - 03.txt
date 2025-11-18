For objects to engage with the physics system, they must have collider and rigidbody2d components.

rigidbody2d bodies have three body types
Static
-Used for stationary obstacles, like walls or floors
-Do not receive collision events

Kinematic
-Used for objects that move solely based on coding logic
-Do not interact with static or kinematic bodies
 -Collisions can be reported if the "Use Full Kinematic Contacts" option is enabled, but this information must be used and acted upon in scripts
-Interact with dynamic bodies as if they have infinite mass

Dynamic
-Are subject to collisions with all body types
-May be affected by gravity (can be amplified/disabled with Gravity Scale value)
-Can also be affected by scripting

If you want to have physics interactions with an object that has a fixed orientation, enable "Freeze Rotation - Z" under Constraints. This can similarly be used to restrict movement to the x or y (world) axes.