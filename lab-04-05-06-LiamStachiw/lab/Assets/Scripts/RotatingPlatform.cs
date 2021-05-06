using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour {
    private enum Axis { x, y, z };
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Axis rotationAxis;

    // Update is called once per frame
    void Update() {
        if (rotationAxis == Axis.x) {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        else if (rotationAxis == Axis.y) {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (rotationAxis == Axis.z) {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
