using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float range = 2f;
    [SerializeField] private Text interactionText;
    [SerializeField] private LayerMask interactableLayers;

    public bool hasCode = false;
    public bool hasSecrets = false;

    private void Update() {
        RaycastHit hit;
        InteractableObject interactable = null;
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, range, interactableLayers)) {
            interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable) {
                interactionText.text = interactable.GetInteractionText();
            } else {
                interactionText.text = "";
            }
        } else {
            interactionText.text = "";
        }

        if (Input.GetButtonDown("Fire2") && interactable) {
            interactable.Activate();
        }
    }
}
