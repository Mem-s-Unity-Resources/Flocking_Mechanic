# Flocking_Mechanic
Unity flocking mechanic v1

Based on flocking mechanic scripts and tutorial by https://github.com/boardtobits.
Improvements: 
  -Conversion to unity 3D with yDisplacement value to accommodate for terrain altitude
  -Avoidance scripts takes into consideration box or capsule collider dimensions for improved accuracy
  -SteeringCohesion script tracks the position of a "follow target" (can be used to drive the flock)
  -Smooth dampen implemented in the move function which fixed the flock agent glittering

