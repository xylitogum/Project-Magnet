# Project-Magnet
Example Unity Project for the magnetic field physics simulation feature.

Unity Version: 2017.4.3
Lower version may open the project but I can't guarantee the functionality and reliability.

# Example Playtest
Scene file located at: Assets\Magnet\Example\Example.unity

Controls:
- Press 1 to drop a Magnet Bar (which is magnetic).
- Press 2 to drop a coin (which is paramagnetic).
- Click an object to select it, then use WASD or Arrow Keys to move it around. 
- Press Shift to lift the selected object up.

# Script & Parameters
The only key script here is located at: Assets\Magnet\Scripts\Magnetic.cs
The script should be attached to a separate GameObject as the child of the object, and serves as a Magnetic Monopole. There should be a trigger collider on it which indicates how far the magnetic field can reach, since the script simulation iteration is written in the OnTriggerStay function. (See Example for details)

A Magnetic Object can be one of three types of __Polarity__:
- _Neutral_: Does not produce a magnetic field, but can be pulled or pushed by other magnetic fields.
- _North Pole_: Produces a magnetic field that attracts _Neutral_ or _South Pole_ objects, and vice versa for _North Pole_ objects.
- _South Pole_: Produces a magnetic field that attracts _Neutral_ or _North Pole_ objects, and vice versa for _South Pole_ objects.

__Magnetic Power__ is a float value that indicates how much force would be applied to this and the other object.
The Actual Formula that calculates the final force is: F = p1 x p2 / r ^ 2 , where F is the force being calculated, p1 and p2 are the Magnetic Power of the two objects, and r is the distance between them. You can modify the formula in the script as you wish.

The same amount of force is applied on both objects but opposite to each other, according to Newton's Third Law. 

The force cannot exceed the max limit defined as a const float called MAX_FORCE in the script which is set to 10f by default.
The distance will not be considered lower than the parameter called __Min Distance__ as well so as to prevent jittering.


# Notices
- When copying or exporting the scripts, make sure you tune the related project settings (Time, Physics, etc) correctly. Adaptive Force Simulation and reducing Fixed Timestep is highly recommended to make it work without jittering.
- I used namespace on the scripts. Be sure to remove it or include it when calling it from another script.
- Play around with the parameters above until it matches your needs.

