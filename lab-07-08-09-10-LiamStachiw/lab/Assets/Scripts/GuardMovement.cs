using UnityEngine;
using UnityEngine.AI;

public class GuardMovement : MonoBehaviour {
    [SerializeField] Transform[] waypoints;
    [SerializeField] float idleTime = 1f;
    [SerializeField] float closeEnoughDistance = 1f;
    [SerializeField] bool loop = true;

    private NavMeshAgent agent = null;
    private Animator animator = null;

    private int waypointIndex = 0;
    private bool patrolling = true;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if ((agent != null) && (waypoints.Length > 0)) {
            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }

    private void Update() {
        if (!patrolling) {
            return;
        }

        float distanceToTarget = Vector3.Distance(agent.transform.position, waypoints[waypointIndex].position);

        if (distanceToTarget < closeEnoughDistance) {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length) {
                if (loop) {
                    waypointIndex = 0;
                }
                else {
                    patrolling = false;
                    animator.SetFloat("Speed", 0);
                    return;
                }
            }

            agent.SetDestination(waypoints[waypointIndex].position);
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("aaaaaaaaaaa");
    }
}
