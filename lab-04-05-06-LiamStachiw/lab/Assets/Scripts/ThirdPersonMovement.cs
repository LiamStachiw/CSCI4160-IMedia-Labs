using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    float turnSmoothVelocity;
    Vector3 velocity; 
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        animator.SetFloat("Speed", 0f);

        if (direction.magnitude >= 0.1f) {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            animator.SetFloat("Speed", moveDirection.magnitude);
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        }

        if (controller.isGrounded) {
            animator.SetBool("isGrounded", true);
        } else {
            animator.SetBool("isGrounded", false);
        }

        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }

        velocity.y += gravity * Time.deltaTime;

        animator.SetFloat("VerticalSpeed", velocity.y);

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Respawn")) {
            Debug.Log("You failed.");
            animator.SetTrigger("Falling");
        } else if (other.CompareTag("Finish")) {
            Debug.Log("You Win.");
            other.gameObject.SetActive(false);
            animator.SetTrigger("Celebrate");
        }
    }
}
