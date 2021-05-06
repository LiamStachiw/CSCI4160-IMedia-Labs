using UnityEngine;

public class SideToSideMovement : MonoBehaviour {
    [SerializeField] float movementSpeed = 10f;

    void Update() {
        float xDirection = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * (xDirection * movementSpeed * Time.deltaTime));
    }
}