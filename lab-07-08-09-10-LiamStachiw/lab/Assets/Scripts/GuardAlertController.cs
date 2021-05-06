using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAlertController : MonoBehaviour
{
    [SerializeField] private GameObject alarmLights;

    private GameObject guard;
    private GameObject[] keypads;
    private NavMeshAgent nm;
    private GameObject closestKeypad;
    private Animator animator = null;

    private bool buttonPressed = false;

    private void Start() {
        alarmLights.SetActive(false);
        keypads = GameObject.FindGameObjectsWithTag("Keypad");
        closestKeypad = keypads[0];
    }

    private void Update() {
        if(guard != null) {
            float distanceToTarget = Vector3.Distance(nm.transform.position, closestKeypad.transform.position);

            if(distanceToTarget < 1.5f && !buttonPressed) {
                animator.SetFloat("Speed", 0f);
                animator.SetTrigger("pressButton");

                alarmLights.SetActive(true);
                buttonPressed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        guard = other.gameObject;
        nm = other.GetComponentInParent<NavMeshAgent>();
        animator = other.GetComponentInParent<Animator>();

        float shortestDistance = float.MaxValue;

        foreach (GameObject keypad in keypads) {
            float distance = Vector3.Distance(other.gameObject.transform.position, keypad.transform.position);

            if (distance < shortestDistance) {
                shortestDistance = distance;
                closestKeypad = keypad;
            }
        }

        nm.speed = 4f;
        nm.SetDestination(closestKeypad.transform.position);
    }
}
