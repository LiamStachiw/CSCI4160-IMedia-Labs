using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject rightPoint;
    [SerializeField] private GameObject leftPoint;
    [SerializeField] private bool isElevator;

    private bool movingRight;
    private bool movingUp;

    // Update is called once per frame
    void Update()
    {
        if (isElevator) {
            if (movingUp) {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }

            if (transform.position.y >= rightPoint.transform.position.y) {
                movingUp = false;
            }
            else if (transform.position.y <= leftPoint.transform.position.y) {
                movingUp = true;
            }
        }
        else {
            if (movingRight) {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }

            if (transform.position.x >= rightPoint.transform.position.x) {
                movingRight = false;
            }
            else if (transform.position.x <= leftPoint.transform.position.x) {
                movingRight = true;
            }
        }
    }
}
