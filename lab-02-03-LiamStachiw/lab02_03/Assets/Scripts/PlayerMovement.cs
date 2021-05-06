using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed = 5.0f;

    private Rigidbody2D rb;
    private Animator controller;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
    }

    private void Update() {
        float movementX = Input.GetAxis("Horizontal") * movementSpeed;
        float movementY = Input.GetAxis("Vertical") * movementSpeed;

        //move in the x direction
        Vector3 moveX = Vector3.right * movementX * Time.deltaTime;
        transform.Translate(moveX);

        //move in the y direction
        Vector3 moveY = Vector3.up * movementY * Time.deltaTime;
        transform.Translate(moveY);
        controller.SetFloat("Speed", Mathf.Abs(movementY + movementX));

        //determine the direction the sprite should face
        if (movementX < 0f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKeyDown("z")) {
            controller.SetTrigger("IsAttacking");
        }
        else if(Input.GetKeyUp("z")) {
            controller.SetTrigger("NotAttacking");
        }
    }
}
