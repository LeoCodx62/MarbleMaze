# Marble Maze 🎱

A simple Marble Maze game where the player tilts the maze to guide the ball to the exit while avoiding obstacles. Hitting an obstacle results in a loss.

👉 [Play on itch.io](https://leocod.itch.io/marblemaze)

---

## Controls
- **Arrow Up/Down** → tilt forward/backward  
- **Arrow Left/Right** → tilt left/right  

---

## Technical Overview

### MazeController
- Tilts the maze using **torque physics** with angular limits (`maxTiltAngle`).  
- On start, the `Rigidbody` is configured: all positions frozen, Y rotation locked, gravity disabled, and physics enabled (`isKinematic = false`).  
- In `FixedUpdate`, keyboard input is read:  
  - **Vertical (X-axis)** → forward/backward  
  - **Horizontal (Z-axis, inverted)** → left/right  
- Torque is applied to tilt the platform, then `ClampTilt` ensures rotation stays within limits and angular velocity is reset (`rb.angularVelocity = Vector3.zero`).

### Ball–Maze Interaction
- Initially, the maze rotation was set directly, ignoring the ball’s physics.  
- With physics-based control, the ball could slightly move the maze.  
- Maze **mass increased from 1 to 100** to reduce unwanted effects, and `TorqueStrength` adjusted to maintain responsiveness.  
- The ball has a **Physics Material** for realistic bouncing.  
- `angularDrag` left unchanged: too high would dampen player-controlled rotations, too low had minimal effect.

---

## Author
Leonardo – VR527808
