using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera playerView;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float standingSpeed = 8f;
    [SerializeField] private float gravity = -9.81f;

    Vector3 standingCamPosition;
    Vector3 crouchingCamPosition;
    Vector3 velocity;
    private float speed;

    private void Start() {
        standingCamPosition = playerView.transform.localPosition;
        crouchingCamPosition = standingCamPosition;
        crouchingCamPosition.y = crouchingCamPosition.y / 2;
    }

    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        speed = standingSpeed;

        if (Input.GetKey(KeyCode.C)) {
            controller.height = standingHeight / 2;
            speed = standingSpeed / 2;
            playerView.transform.localPosition = crouchingCamPosition;
        }
        else {
            controller.height = standingHeight;
            speed = standingSpeed;
            playerView.transform.localPosition = standingCamPosition;

        }

        if (controller.isGrounded && velocity.y == 0) {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}