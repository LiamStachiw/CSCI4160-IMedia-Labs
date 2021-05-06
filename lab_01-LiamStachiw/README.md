# Lab 01

## Overview

For this lab, you will create a simple coin collector mini-game.  A character sprite will be able to move left and right, while coin sprites infinitely fall from the sky.  If the character comes in contact with a coin, it will disappear and the player's score will be increased.

## Gathering Assets

Collect a character sprite (a single image) and a coin sprite from any source online.  The character sprite and coin sprite image can be any size that you like, though you may find that you need to resize them to make the game more playable (more or less difficult, as required).  You can get assets from anywhere you want, but here are a few good sources:

- https://opengameart.org/
- https://kenney.nl/assets?q=2d
- https://www.gameart2d.com/freebies.html

_**Note:** Ensure that you have the rights to use these sprites, including any attribution in your project as required._

## Character Movement

Drag in the character image into your scene, and name it `Player`.  Add a collider to this player (either a `CapsuleCollider2D` or a `BoxCollider2D`, whichever matches your sprite best).  Set this collider as a trigger.  Add a `RigidBody2D` component to `Player` and set its type to `Kinematic`, so that it doesn't fall off the screen.

We will cover character movement in a future lecture.  For now, add the following script to your character to allow it to move left or right:

```
using UnityEngine;

public class SideToSideMovement : MonoBehaviour {
    [SerializeField] float movementSpeed = 10f;

    void Update() {
        float xDirection = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * (xDirection * movementSpeed * Time.deltaTime));
    }
}
```

## Coin Spawning

Drag in the coin image into your scene, and name it `Coin`.  Write a script, called `DropSpawner`, which will check to see if a coin has moved off screen, and if so, will call the `Respawn()` function.  The `Respawn()` function will teleport that coin back above the top of the screen.  This function will be public.  If the `Coin` is on screen, then it will fall at a constant speed (which will be set using a parameter, `fallSpeed`, a float).  Use the above script for inspiration for this part.  Attach this script to the `Coin` object, and test it out to make sure it falls off the screen, and re-spawns at the top.

## Coin Collection

Create a collider (a `CircleCollider2D` is probably the best fit) for the `Coin` game object, and create a script (called `PlayerScore`) that implements the `onTriggerEnter2D` event handler and has an integer public field exposed, called `playerScore`.  When this happens, you will re-spawn the `Coin` (by calling `Respawn()`) and increment `playerScore`.

## Create a Level

Make a prefab out of your `Coin` game object (drag it into the assets, into a folder called `Prefabs`).  Drag several of these `Coin` prefabs into your scene, at various x positions within the visible screen area, and at various y positions above the visible screen area.

## How to Submit

To submit this lab, you only need to commit and push your code to your copy of this repository.  It is advisable, especially if you are new to git and GitHub, to verify that your most up-to-date code appears on GitHub.